using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Capri.Database.Entities.Identity;

namespace Capri.Database.Entities.Configuration
{
    public class GuidRoleConfiguration : IEntityTypeConfiguration<GuidRole>
    {
        public void Configure(EntityTypeBuilder<GuidRole> builder)
        {
            builder.HasData(
                new GuidRole
                {
                    Id = SeedGetter.DeanRoleId,
                    Name = RoleType.Dean,
                    NormalizedName = RoleType.Dean
                },
                new GuidRole
                {
                    Id = SeedGetter.StudentRoleId,
                    Name = RoleType.Student,
                    NormalizedName = RoleType.Student
                },
                new GuidRole
                {
                    Id = SeedGetter.PromoterRoleId,
                    Name = RoleType.Promoter,
                    NormalizedName = RoleType.Promoter
                });
        }
    }
}
