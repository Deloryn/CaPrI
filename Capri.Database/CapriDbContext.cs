using System;
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
            modelBuilder.Entity<Promoter>()
                .HasOne(p => p.Institute)
                .WithMany(i => i.Promoters)
                .HasForeignKey(p => p.InstituteId);

            modelBuilder.Entity<Proposal>()
                .HasMany(p => p.Students)
                .WithOne();

            modelBuilder.Entity<Proposal>()
                .HasOne(pl => pl.Promoter)
                .WithMany(pr => pr.Proposals)
                .HasForeignKey(p => p.PromoterId);

            modelBuilder.Entity<Proposal>()
                .HasOne(p => p.Course)
                .WithMany(c => c.Proposals)
                .HasForeignKey(p => p.CourseId);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Faculty)
                .WithMany(f => f.Courses)
                .HasForeignKey(c => c.FacultyId);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new GuidRoleConfiguration());
            modelBuilder.ApplyConfiguration(new GuidUserRoleConfiguration());

            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new PromoterConfiguration());

            modelBuilder.ApplyConfiguration(new ProposalConfiguration());

            modelBuilder.ApplyConfiguration(new InstituteConfiguration());
            modelBuilder.ApplyConfiguration(new FacultyConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
        }
    }
}
