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
            foreach(Guid adminId in SeedParams.AdminIds)
            {
                builder.HasData(new GuidUserRole
                {
                    Id = Guid.NewGuid(),
                    RoleId = SeedParams.AdminRoleId,
                    UserId = adminId
                });
            }
            foreach (Guid deanId in SeedParams.DeanIds)
            {
                builder.HasData(new GuidUserRole
                {
                    Id = Guid.NewGuid(),
                    RoleId = SeedParams.DeanRoleId,
                    UserId = deanId
                });
            }
            foreach (Guid studentId in SeedParams.StudentIds)
            {
                builder.HasData(new GuidUserRole
                {
                    Id = Guid.NewGuid(),
                    RoleId = SeedParams.StudentRoleId,
                    UserId = studentId
                });
            }
            foreach (Guid promoterId in SeedParams.PromoterIds)
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
