using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Capri.Database.Entities.Configuration
{
    public class PromoterConfiguration : IEntityTypeConfiguration<Promoter>
    {
        public void Configure(EntityTypeBuilder<Promoter> builder)
        {
            builder.HasData(SeedGetter.Promoters.ToArray());
        }
    }
}
