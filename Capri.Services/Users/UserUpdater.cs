using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Capri.Database;
using Capri.Database.Entities.Identity;
using Capri.Web.ViewModels.User;

namespace Capri.Services.Users
{
    public class UserUpdater : IUserUpdater
    {
        private readonly ISqlDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<GuidRole> _roleManager;

        public UserUpdater(
            ISqlDbContext context,
            UserManager<User> userManager,
            RoleManager<GuidRole> roleManager
            )
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IServiceResult<User>> Update(
            Guid id,
            UserCredentials credentials,
            IEnumerable<string> roles)
        {
            var existingUser = await _userManager.FindByIdAsync(id.ToString());
            if (existingUser == null)
            {
                return ServiceResult<User>.Error(
                    $"User with id {id} does not exist");
            }

            var isEmailTakenBySomeOneElse = await IsEmailTakenBySomeoneElse(credentials.Email);
            if(isEmailTakenBySomeOneElse)
            {
                return ServiceResult<User>.Error(
                    $"Email {credentials.Email} is already taken by another user"
                );
            }

            foreach(var role in roles)
            {
                var roleExists = await _roleManager.RoleExistsAsync(role);
                if(!roleExists)
                {
                    return ServiceResult<User>.Error(
                        $"Role {role} does not exist");
                }
            }

            UpdateCredentialsOf(existingUser, credentials);
            
            var currentRoles = await _userManager.GetRolesAsync(existingUser);
            await _userManager.RemoveFromRolesAsync(existingUser, currentRoles);
            await _userManager.AddToRolesAsync(existingUser, roles);
            
            await _userManager.UpdateAsync(existingUser);
            await _context.SaveChangesAsync();

            return ServiceResult<User>.Success(existingUser);
        }

        private async Task<bool> IsEmailTakenBySomeoneElse(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user == null)
            {
                return false;
            }
            return true;
        }

        private void UpdateCredentialsOf(
            User user,
            UserCredentials credentials)
        {
            string email = credentials.Email;
            string password = credentials.Password;

            user.UserName = email;
            user.NormalizedUserName =
                    new UpperInvariantLookupNormalizer()
                        .Normalize(email)
                        .ToUpperInvariant();
            user.Email = email;
            user.NormalizedEmail =
                    new UpperInvariantLookupNormalizer()
                        .Normalize(email)
                        .ToUpperInvariant();
            user.PasswordHash =
                new PasswordHasher<User>()
                .HashPassword(user, password);
        }
    }
}
