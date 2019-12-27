using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;
using Capri.Database.Entities.Identity;
using Microsoft.Extensions.Options;

namespace Capri.Database.Entities.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            for (int i = 1; i <= SeedParams.DeanIds.Length; i++)
            {
                string email = "dean" + i.ToString() + "@gmail.com";
                string password = "qwerty" + i.ToString();
                builder.HasData(new User
                {
                    Id = SeedParams.DeanIds[i - 1],
                    UserName = email,
                    NormalizedUserName = email,
                    Email = email,
                    NormalizedEmail = email,
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<User>().HashPassword(null, password),
                    SecurityStamp = string.Empty
                });
            }

            for (int i = 1; i <= SeedParams.StudentIds.Length; i++)
            {
                string email = "student" + i.ToString() + "@gmail.com";
                string password = "qwerty" + i.ToString();
                builder.HasData(new User
                {
                    Id = SeedParams.StudentIds[i - 1],
                    UserName = email,
                    NormalizedUserName = email,
                    Email = email,
                    NormalizedEmail = email,
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<User>().HashPassword(null, password),
                    SecurityStamp = string.Empty
                });
            }

            for (int i = 1; i <= SeedParams.PromoterIds.Length; i++)
            {
                string email = "promoter" + i.ToString() + "@gmail.com";
                string password = "qwerty" + i.ToString();
                builder.HasData(new User
                {
                    Id = SeedParams.PromoterIds[i - 1],
                    UserName = email,
                    NormalizedUserName = email,
                    Email = email,
                    NormalizedEmail = email,
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<User>().HashPassword(null, password),
                    SecurityStamp = string.Empty,
                });
            }
        }
    }
}
