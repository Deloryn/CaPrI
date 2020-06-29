using System.Linq;
using Capri.Database;
using Capri.Database.Entities.Identity;

namespace Capri.Synchronizer.Synchronizers
{
    public class RoleSynchronizer : IRoleSynchronizer
    {
        private readonly ISqlDbContext _context;
        public RoleSynchronizer(ISqlDbContext context)
        {
            _context = context;
        }

        public void Synchronize()
        {
            var roles = new IntRole[] {
                new IntRole() {
                    Id = 0,
                    Name = "Promoter",
                    NormalizedName = "Promoter"
                },
                new IntRole() {
                    Id = 1,
                    Name = "Dean",
                    NormalizedName = "Dean"
                },
                new IntRole() {
                    Id = 2,
                    Name = "Admin",
                    NormalizedName = "Admin"
                }
            };

            AddOrUpdateRange(roles);
            _context.SaveChanges();
        }
        
        private void AddOrUpdateRange(IntRole[] roles)
        {
            foreach(var role in roles)
            {
                AddOrUpdate(role);
            }
        }

        private void AddOrUpdate(IntRole role)
        {
            if(_context.Roles.Any(r => r.Id == role.Id))
            {
                _context.Roles.Update(role);
            }
            else
            {
                _context.Roles.Add(role);
            }
        }
    }
}