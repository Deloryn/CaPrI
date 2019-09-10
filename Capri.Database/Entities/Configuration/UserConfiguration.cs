using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;
using Capri.Database.Entities.Identity;

namespace Capri.Database.Entities.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var user = new User { Id = Guid.NewGuid(), UserName = "admin@gmail.com", Email = "admin@gmail.com" };
            user.PasswordHash = new PasswordHasher<User>().HashPassword(user, "qwerty");
            builder.HasData(user);
        }
    }
}
