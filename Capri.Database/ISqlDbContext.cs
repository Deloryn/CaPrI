using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Capri.Database.Entities;
using Capri.Database.Entities.Identity;

namespace Capri.Database
{
    public interface ISqlDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<IntRole> Roles { get; set; }
        DbSet<Promoter> Promoters { get; set; }
        DbSet<Proposal> Proposals { get; set; }
        DbSet<Faculty> Faculties { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<Institute> Institutes { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
