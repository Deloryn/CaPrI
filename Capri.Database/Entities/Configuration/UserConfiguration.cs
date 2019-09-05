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
        private readonly UserManager<User> _userManager;

        public UserConfiguration(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async void Configure(EntityTypeBuilder<User> builder)
        {
            string email = "admin@gmail.com";
            string password = "qwerty";
            var user = new User { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
        }
    }
}
