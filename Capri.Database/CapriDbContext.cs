using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Capri.Database.Entities;
using Capri.Database.Entities.Configuration;

using Capri.Database.Entities.Identity;

namespace Capri.Database
{
    public class CapriDbContext : IdentityDbContext<User, GuidRole, Guid, GuidUserClaim, GuidUserRole, GuidUserLogin,
        GuidRoleClaim, GuidUserToken>, ISqlDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Promoter> Promoters { get; set; }
        public DbSet<DeanEmployee> DeanEmployees { get; set; }
        public DbSet<BachelorProposal> BachelorProposals { get; set; }
        public DbSet<MasterProposal> MasterProposals { get; set; }

        public CapriDbContext(DbContextOptions<CapriDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Promoter>()
                .HasMany(p => p.Proposals)
                .WithOne();

            modelBuilder.Entity<Proposal>()
                .HasMany(p => p.AssignedStudents)
                .WithOne();

            modelBuilder.Entity<Proposal>()
                .HasMany(p => p.WillingCandidates)
                .WithOne();

            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
