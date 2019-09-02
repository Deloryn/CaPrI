using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Capri.DataLayer.Entities;

namespace Capri.DataLayer.Contexts
{
    public abstract class CapriDbContext : DbContext
    {
        public CapriDbContext() : base()
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Promoter> Promoters { get; set; }
        public DbSet<DeanEmployee> DeanEmployees { get; set; }
        public DbSet<BachelorProposal> BachelorProposals { get; set; }
        public DbSet<MasterProposal> MasterProposals { get; set; }
    }
}
