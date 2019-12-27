using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Capri.Database;
using Capri.Database.Entities.Identity;
using Capri.Web.ViewModels.User;

namespace Capri.Services.Users
{
    public class UserUpdater : IUserUpdater
    {
        private readonly ISqlDbContext _context;
        private readonly UserManager<User> _userManager;

        public UserUpdater(
            ISqlDbContext context,
            UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IServiceResult<User>> Update(
            Guid id,
            UserCredentials credentials)
        {
            var existingUser =
                await _context
                .Users
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existingUser == null)
            {
                return ServiceResult<User>.Error(
                    $"User with id {id} does not exist");
            }

            UpdateCredentialsOf(existingUser, credentials);

            await _userManager.UpdateAsync(existingUser);
            await _context.SaveChangesAsync();

            return ServiceResult<User>.Success(existingUser);
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
