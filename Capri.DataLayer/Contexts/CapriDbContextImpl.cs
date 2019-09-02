using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Capri.DataLayer.Entities;

namespace Capri.DataLayer.Contexts
{
    public class CapriDbContextImpl : CapriDbContext
    {
        public CapriDbContextImpl() : base()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Proposal>().ToTable("Proposals");

            modelBuilder.Entity<Promoter>()
                .HasMany(p => p.Proposals)
                .WithOne();

            modelBuilder.Entity<Proposal>()
                .HasMany(p => p.AssignedStudents)
                .WithOne();

            modelBuilder.Entity<Proposal>()
                .HasMany(p => p.WillingCandidates)
                .WithOne();

            var seedUser1 = new Promoter
            {
                ID = 1,
                Name = "John Smith",
                Email = "john.smith@gmail.com",
                CanSubmitBachelorProposals = true
            };
            seedUser1.PasswordHash = new PasswordHasher<User>().HashPassword(seedUser1, "qwerty");

            var seedUser2 = new DeanEmployee
            {
                ID = 2,
                Name = "Admin",
                Email = "admin@gmail.com",
            };
            seedUser2.PasswordHash = new PasswordHasher<User>().HashPassword(seedUser2, "qwerty");

            modelBuilder.Entity<Promoter>().HasData(seedUser1);
            modelBuilder.Entity<DeanEmployee>().HasData(seedUser2);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CapriDB;Trusted_Connection=True;");
        }
    }
}
