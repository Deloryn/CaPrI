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
                    Name = "dean",
                    NormalizedName = "dean"
                },
                new GuidRole
                {
                    Id = SeedGetter.StudentRoleId,
                    Name = "student",
                    NormalizedName = "student"
                },
                new GuidRole
                {
                    Id = SeedGetter.PromoterRoleId,
                    Name = "promoter",
                    NormalizedName = "promoter"
                });
        }
    }
}
