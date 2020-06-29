using System.Linq;
using Microsoft.AspNetCore.Identity;
using Capri.Database;
using Capri.Database.Entities.Identity;

namespace Capri.Synchronizer.Synchronizers
{
    public class AdminAccountSynchronizer : IAdminAccountSynchronizer
    {
        private readonly ISqlDbContext _context;
        private readonly string _adminEmail;
        private readonly string _adminPassword;

        public AdminAccountSynchronizer(ISqlDbContext context, string adminEmail, string adminPassword)
        {
            _context = context;
            _adminEmail = adminEmail;
            _adminPassword = adminPassword;
        }

        public void Synchronize() {
            var user = CreateAdminAccount();
            AddOrUpdate(user);
            _context.SaveChanges();
        }

        private User CreateAdminAccount() {
            string normalizedEmail = GetNormalizedEmail(_adminEmail);
            return new User() {
                Id = 1,
                EmailConfirmed = true,
                Email = normalizedEmail,
                NormalizedEmail = normalizedEmail,
                UserName = normalizedEmail,
                NormalizedUserName = normalizedEmail,
                PasswordHash = new PasswordHasher<User>().HashPassword(null, _adminPassword),
                SecurityStamp = ""
            };            
        }
        
        private string GetNormalizedEmail(string email)
        {
            return new UpperInvariantLookupNormalizer()
                .Normalize(email)
                .ToLowerInvariant();
        }

        private void AddOrUpdate(User user)
        {
            if(_context.Users.Any(u => u.Id == user.Id))
            {
                _context.Users.Update(user);
            }
            else
            {
                _context.Users.Add(user);
                _context.UserRoles.Add(new IntUserRole {
                    UserId = user.Id,
                    RoleId = GetAdminRole().Id
                });
            }
        }

        private IntRole GetAdminRole() {
            return _context.Roles.FirstOrDefault(r => r.Name == "Admin");
        }

     }
}