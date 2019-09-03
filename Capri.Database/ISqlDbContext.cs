using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Capri.Database.Entities;

namespace Capri.Database
{
    public interface ISqlDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Promoter> Promoters { get; set; }
        DbSet<DeanEmployee> DeanEmployees { get; set; }
        DbSet<BachelorProposal> BachelorProposals { get; set; }
        DbSet<MasterProposal> MasterProposals { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
