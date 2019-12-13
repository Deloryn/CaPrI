using System;
using System.Collections.Generic;
using System.Text;
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
                    Id = SeedParams.DeanRoleId,
                    Name = "dean",
                    NormalizedName = "dean"
                },
                new GuidRole
                {
                    Id = SeedParams.StudentRoleId,
                    Name = "student",
                    NormalizedName = "student"
                },
                new GuidRole
                {
                    Id = SeedParams.PromoterRoleId,
                    Name = "promoter",
                    NormalizedName = "promoter"
                });
        }
    }
}
