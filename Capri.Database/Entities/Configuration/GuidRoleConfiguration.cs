using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Capri.Database.Entities.Identity;

namespace Capri.Database.Entities.Configuration
{
    public class GuidRoleConfiguration : IEntityTypeConfiguration<GuidRole>
    {
        public void Configure(EntityTypeBuilder<GuidRole> builder)
        {
            var deanRoleName = Enum.GetName(typeof(RoleType), RoleType.Dean);
            var studentRoleName = Enum.GetName(typeof(RoleType), RoleType.Student);
            var promoterRoleName = Enum.GetName(typeof(RoleType), RoleType.Promoter);

            builder.HasData(
                new GuidRole
                {
                    Id = SeedGetter.DeanRoleId,
                    Name = deanRoleName,
                    NormalizedName = deanRoleName
                },
                new GuidRole
                {
                    Id = SeedGetter.StudentRoleId,
                    Name = studentRoleName,
                    NormalizedName = studentRoleName
                },
                new GuidRole
                {
                    Id = SeedGetter.PromoterRoleId,
                    Name = promoterRoleName,
                    NormalizedName = promoterRoleName
                });
        }
    }
}
