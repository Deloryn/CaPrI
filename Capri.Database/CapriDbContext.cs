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
            modelBuilder.Entity<Institute>()
                .HasIndex(i => i.Name)
                .IsUnique();

            modelBuilder.Entity<Faculty>()
                .HasIndex(f => f.Name)
                .IsUnique();

            modelBuilder.Entity<Promoter>()
                .HasOne(p => p.Institute)
                .WithMany(i => i.Promoters)
                .HasForeignKey(p => p.InstituteId);

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

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Proposal)
                .WithMany(p => p.Students)
                .HasForeignKey(s => s.ProposalId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Student>()
                .HasIndex(s => s.IndexNumber)
                .IsUnique();

            modelBuilder.Entity<GuidUserRole>()
                .HasKey(userRole => new { userRole.UserId, userRole.RoleId });

            modelBuilder.Entity<GuidUserRole>()
                .Property(userRole => userRole.Id)
                .ValueGeneratedOnAdd();
                

            // modelBuilder.ApplyConfiguration(new UserConfiguration());
            // modelBuilder.ApplyConfiguration(new GuidRoleConfiguration());
            // modelBuilder.ApplyConfiguration(new GuidUserRoleConfiguration());

            // modelBuilder.ApplyConfiguration(new StudentConfiguration());
            // modelBuilder.ApplyConfiguration(new PromoterConfiguration());

            // modelBuilder.ApplyConfiguration(new ProposalConfiguration());

            // modelBuilder.ApplyConfiguration(new InstituteConfiguration());
            // modelBuilder.ApplyConfiguration(new FacultyConfiguration());
            // modelBuilder.ApplyConfiguration(new CourseConfiguration());
        }
    }
}
