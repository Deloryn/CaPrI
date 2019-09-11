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
            for (int i = 1; i <= SeedParams.PromoterIds.Length; i++)
            {
                string email = "promoter" + i.ToString() + "@gmail.com";
                string password = "qwerty" + i.ToString();
                builder.HasData(new Promoter
                {
                    Id = SeedParams.PromoterIds[i - 1],
                    UserName = email,
                    NormalizedUserName = email,
                    Email = email,
                    NormalizedEmail = email,
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<User>().HashPassword(null, password),
                    SecurityStamp = string.Empty,
                    CanSubmitBachelorProposals = true
                });
            }
        }
    }
}
