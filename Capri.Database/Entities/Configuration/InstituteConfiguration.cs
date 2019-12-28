using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Capri.Database.Entities.Configuration
{
    public class InstituteConfiguration : IEntityTypeConfiguration<Institute>
    {
        public void Configure(EntityTypeBuilder<Institute> builder)
        {
            builder.HasData(SeedGetter.Institutes.ToArray());
        }
    }
}