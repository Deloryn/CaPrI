using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Capri.Database.Entities.Identity;

namespace Capri.Database.Entities.Configuration
{
    public class GuidUserRoleConfiguration : IEntityTypeConfiguration<GuidUserRole>
    {
        public void Configure(EntityTypeBuilder<GuidUserRole> builder)
        {
            foreach (var deanId in SeedParams.DeanIds)
            {
                builder.HasData(new GuidUserRole
                {
                    Id = Guid.NewGuid(),
                    RoleId = SeedParams.DeanRoleId,
                    UserId = deanId
                });
            }
            foreach (var studentId in SeedParams.StudentIds)
            {
                builder.HasData(new GuidUserRole
                {
                    Id = Guid.NewGuid(),
                    RoleId = SeedParams.StudentRoleId,
                    UserId = studentId
                });
            }
            foreach (var promoterId in SeedParams.PromoterIds)
            {
                builder.HasData(new GuidUserRole
                {
                    Id = Guid.NewGuid(),
                    RoleId = SeedParams.PromoterRoleId,
                    UserId = promoterId
                });
            }
        }
    }
}
