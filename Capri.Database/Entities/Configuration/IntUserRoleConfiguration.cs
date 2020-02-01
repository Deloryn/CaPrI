using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Capri.Database.Entities.Identity;

namespace Capri.Database.Entities.Configuration
{
    public class IntUserRoleConfiguration : IEntityTypeConfiguration<IntUserRole>
    {
        public void Configure(EntityTypeBuilder<IntUserRole> builder)
        {
            // foreach (var userId in SeedGetter.DeanEmployees.Select(d => d.Id))
            // {
            //     builder.HasData(new IntUserRole
            //     {
            //         // Id = Guid.NewGuid(),
            //         RoleId = SeedGetter.DeanRoleId,
            //         UserId = userId
            //     });
            // }
            // foreach (var userId in SeedGetter.Students.Select(s => s.UserId))
            // {
            //     builder.HasData(new IntUserRole
            //     {
            //         // Id = Guid.NewGuid(),
            //         RoleId = SeedGetter.StudentRoleId,
            //         UserId = userId
            //     });
            // }
            // foreach (var userId in SeedGetter.Promoters.Select(p => p.UserId))
            // {
            //     builder.HasData(new IntUserRole
            //     {
            //         // Id = Guid.NewGuid(),
            //         RoleId = SeedGetter.PromoterRoleId,
            //         UserId = userId
            //     });
            // }
        }
    }
}
