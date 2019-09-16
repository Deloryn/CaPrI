using System;
using System.Collections.Generic;
using System.Text;
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
        DbSet<Student> Students { get; set; }
        DbSet<Promoter> Promoters { get; set; }
        DbSet<Proposal> Proposals { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
