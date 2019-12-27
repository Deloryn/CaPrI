using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Capri.Database.Entities.Identity;

namespace Capri.Database.Entities.Configuration
{
    public class GuidUserRoleConfiguration : IEntityTypeConfiguration<GuidUserRole>
    {
        public void Configure(EntityTypeBuilder<GuidUserRole> builder)
        {
            foreach (var userId in SeedGetter.DeanEmployees.Select(d => d.Id))
            {
                builder.HasData(new GuidUserRole
                {
                    Id = Guid.NewGuid(),
                    RoleId = SeedGetter.DeanRoleId,
                    UserId = userId
                });
            }
            foreach (var userId in SeedGetter.Students.Select(s => s.UserId))
            {
                builder.HasData(new GuidUserRole
                {
                    Id = Guid.NewGuid(),
                    RoleId = SeedGetter.StudentRoleId,
                    UserId = userId
                });
            }
            foreach (var userId in SeedGetter.Promoters.Select(p => p.UserId))
            {
                builder.HasData(new GuidUserRole
                {
                    Id = Guid.NewGuid(),
                    RoleId = SeedGetter.PromoterRoleId,
                    UserId = userId
                });
            }
        }
    }
}
