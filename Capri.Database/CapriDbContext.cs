﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Capri.Database.Entities;
using Capri.Database.Entities.Configuration;

using Capri.Database.Entities.Identity;

namespace Capri.Database
{
    public class CapriDbContext : IdentityDbContext
        <User, GuidRole, Guid, GuidUserClaim, GuidUserRole, GuidUserLogin,
        GuidRoleClaim, GuidUserToken>, 
        ISqlDbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Promoter> Promoters { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Institute> Institutes { get; set; }

        public CapriDbContext(
            DbContextOptions<CapriDbContext> dbContextOptions
            ) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proposal>()
                .HasMany(p => p.Students)
                .WithOne();

            modelBuilder.Entity<Proposal>()
                .HasOne(pl => pl.Promoter)
                .WithMany(pr => pr.Proposals)
                .HasForeignKey(p => p.PromoterId);

            modelBuilder.Entity<Faculty>()
                .HasMany(f => f.Courses)
                .WithOne();

            modelBuilder.Entity<Institute>()
                .HasMany(i => i.Promoters)
                .WithOne();

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new PromoterConfiguration());
            modelBuilder.ApplyConfiguration(new GuidRoleConfiguration());
            modelBuilder.ApplyConfiguration(new GuidUserRoleConfiguration());
        }
    }
}
