using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Capri.Database.Entities;

namespace Capri.Database
{
    public class SqlDbContext : DbContext, ISqlDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Promoter> Promoters { get; set; }
        public DbSet<DeanEmployee> DeanEmployees { get; set; }
        public DbSet<BachelorProposal> BachelorProposals { get; set; }
        public DbSet<MasterProposal> MasterProposals { get; set; }

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
        }
    }
}
