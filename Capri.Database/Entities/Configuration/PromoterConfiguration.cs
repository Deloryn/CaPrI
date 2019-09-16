using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Capri.Database.Entities.Identity;

namespace Capri.Database.Entities.Configuration
{
    public class PromoterConfiguration : IEntityTypeConfiguration<Promoter>
    {
        public void Configure(EntityTypeBuilder<Promoter> builder)
        {
            foreach(var userId in SeedParams.PromoterIds)
            {
                builder.HasData(new Promoter
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    CanSubmitBachelorProposals = true
                });
            }
        }
    }
}
