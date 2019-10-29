using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Capri.Database;
using Capri.Database.Entities;
using Capri.Database.Entities.Identity;
using Capri.Web.ViewModels.Promoter;

namespace Capri.Services
{
    public class PromoterCreator : IPromoterCreator
    {
        private readonly ISqlDbContext _context;

        public PromoterCreator(ISqlDbContext context)
        {
            _context = context;
        }

        public IServiceResult<Promoter> Create(PromoterRegistration registration)
        {
            if (EmailExists(registration.Email))
            {
                return ServiceResult<Promoter>.Error("Email already taken");
            }

            var user = CreateUser(registration.Email, registration.Password);
            _context.Users.Add(user);

            Promoter promoter = new Promoter
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                CanSubmitBachelorProposals = registration.CanSubmitBachelorProposals,
                CanSubmitMasterProposals = registration.CanSubmitMasterProposals
            };

            _context.Promoters.Add(promoter);

            _context.SaveChangesAsync();
            return ServiceResult<Promoter>.Success(promoter);
        }

        private bool EmailExists(string email)
        {
            if (_context.Users.Any(_ => _.Email == email))
            {
                return true;
            }
            return false;
        }

        private User CreateUser(string email, string password)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                UserName = email,
                NormalizedUserName = email,
                Email = email,
                NormalizedEmail = email,
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<User>().HashPassword(null, password),
                SecurityStamp = string.Empty
            };
        }
    }
}
