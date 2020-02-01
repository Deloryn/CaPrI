using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Capri.Database.Entities.Identity;

namespace Capri.Database.Entities.Configuration
{
    public class IntRoleConfiguration : IEntityTypeConfiguration<IntRole>
    {
        public void Configure(EntityTypeBuilder<IntRole> builder)
        {
            var deanRoleName = Enum.GetName(typeof(RoleType), RoleType.Dean);
            var studentRoleName = Enum.GetName(typeof(RoleType), RoleType.Student);
            var promoterRoleName = Enum.GetName(typeof(RoleType), RoleType.Promoter);

            builder.HasData(
                new IntRole
                {
                    Id = SeedGetter.DeanRoleId,
                    Name = deanRoleName,
                    NormalizedName = deanRoleName
                },
                new IntRole
                {
                    Id = SeedGetter.StudentRoleId,
                    Name = studentRoleName,
                    NormalizedName = studentRoleName
                },
                new IntRole
                {
                    Id = SeedGetter.PromoterRoleId,
                    Name = promoterRoleName,
                    NormalizedName = promoterRoleName
                });
        }
    }
}
