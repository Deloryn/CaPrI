using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Capri.Database.Entities;

using Capri.Database.Entities.Identity;

namespace Capri.Database
{
    public class CapriDbContext : IdentityDbContext
        <User, IntRole, int, IntUserClaim, IntUserRole, IntUserLogin,
        IntRoleClaim, IntUserToken>, 
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

            modelBuilder.Entity<IntUserRole>()
                .HasKey(userRole => new { userRole.UserId, userRole.RoleId });

            modelBuilder.Entity<IntUserRole>()
                .Property(userRole => userRole.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
