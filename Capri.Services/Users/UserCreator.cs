using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Capri.Database;
using Capri.Database.Entities.Identity;
using Capri.Services.Token;

namespace Capri.Services.Users
{
    public class UserCreator : IUserCreator
    {
        private readonly ISqlDbContext _context;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IntRole> _roleManager;

        public UserCreator(
            ISqlDbContext context,
            ITokenGenerator tokenGenerator,
            UserManager<User> userManager,
            RoleManager<IntRole> roleManager
            )
        {
            _context = context;
            _tokenGenerator = tokenGenerator;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IServiceResult<User>> CreateUser(
            string email, 
            string password,
            RoleType[] roles)
        {
            var emailExists = await EmailExists(email);
            if(emailExists)
            {
                return ServiceResult<User>.Error(
                    $"Email {email} is already taken");
            }

            var roleNames = roles.Select(r => GetRoleName(r));
            foreach(var roleName in roleNames)
            {
                var roleExists = await _roleManager.RoleExistsAsync(roleName);
                if(!roleExists)
                {
                    return ServiceResult<User>.Error(
                        $"Role {roleName} does not exist");
                }
            }

            var user = new User
            {
                UserName = email,
                NormalizedUserName =
                    new UpperInvariantLookupNormalizer()
                        .Normalize(email)
                        .ToUpperInvariant(),
                Email = email,
                NormalizedEmail =
                    new UpperInvariantLookupNormalizer()
                        .Normalize(email)
                        .ToUpperInvariant(),
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<User>().HashPassword(null, password),
            };

            user.SecurityStamp = _tokenGenerator.GenerateTokenFor(user);

            await _userManager.CreateAsync(user);
            await _userManager.AddToRolesAsync(user, roleNames);
            await _context.SaveChangesAsync();

            return ServiceResult<User>.Success(user);
        }

        private async Task<bool> EmailExists(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user != null)
            {
                return true;
            }
            return false;
        }

        private string GetRoleName(RoleType role)
        {
            return Enum.GetName(typeof(RoleType), role);
        }
    }
}
