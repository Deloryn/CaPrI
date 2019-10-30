using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Capri.Database;
using Capri.Database.Entities.Identity;

namespace Capri.Services
{
    public class UserCreator : IUserCreator
    {
        private readonly ISqlDbContext _context;
        private readonly ITokenGenerator _tokenGenerator;

        public UserCreator(
            ISqlDbContext context,
            ITokenGenerator tokenGenerator)
        {
            _context = context;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<IServiceResult<User>> CreateUser(
            string email, 
            string password)
        {
            var emailExists = await EmailExists(email);
            if(emailExists)
            {
                return ServiceResult<User>.Error("Email already taken");
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
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

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return ServiceResult<User>.Success(user);
        }

        private async Task<bool> EmailExists(string email)
        {
            return await _context.Users.AnyAsync(_ => _.Email == email);
        }
    }
}
