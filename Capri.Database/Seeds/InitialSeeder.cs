using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capri.Database.Entities;
using Microsoft.AspNetCore.Identity;

namespace Capri.Database.Seeds
{
    public class InitialSeeder : ISeeder
    {
        private readonly ISqlDbContext _context;

        public InitialSeeder(ISqlDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            AddNewPromoter("John Smith", "admin@gmail.com", "qwerty");
            _context.SaveChangesAsync();
        }

        private void AddNewPromoter(string name, string email, string password, bool canSubmitBachelorProposals = false)
        {
            var existingPromoter = _context.Promoters.FirstOrDefault(u => u.Email == email);
            if (existingPromoter == null)
            {
                Promoter promoter = new Promoter { Name = name, Email = email, CanSubmitBachelorProposals = canSubmitBachelorProposals };
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                string passwordHash = hasher.HashPassword(promoter, password);
                _context.Users.Add(promoter);
            }
        }
    }
}
