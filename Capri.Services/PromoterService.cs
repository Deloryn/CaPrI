using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Capri.Database;
using Capri.Database.Entities;
using Capri.Database.Entities.Identity;
using Capri.Web.ViewModels.Promoter;

namespace Capri.Services
{
    public class PromoterService : IPromoterService
    {
        private readonly ISqlDbContext _context;

        public PromoterService(ISqlDbContext context)
        {
            _context = context;
        }

        public IServiceResult<Promoter> Get(Guid id)
        {
            Promoter promoter = _context.Promoters.Find(id);
            if (promoter == null)
            {
                return ServiceResult<Promoter>.Error(
                    "Promoter with given id does not exist");
            }
            else
            {
                return ServiceResult<Promoter>.Success(promoter);
            }
        }

        public IServiceResult<List<Promoter>> GetAll()
        {
            var promoters = _context.Promoters.ToList();
            return ServiceResult<List<Promoter>>.Success(promoters);
        }

        public IServiceResult<Promoter> Update(PromoterUpdate newData)
        {
            Promoter existingPromoter = _context.Promoters.Find(newData.Id);
            if(existingPromoter == null)
            {
                return ServiceResult<Promoter>.Error(
                    "Promoter with the given does not exist");
            }

            User existingUser = _context.Users.Find(newData.UserId);
            if(existingUser == null)
            {
                return ServiceResult<Promoter>.Error(
                    "User with the given id does not exist");
            }

            existingPromoter.UserId = newData.UserId;
            existingPromoter.Proposals = GetProposalsWithIds(newData.ProposalsIds);
            existingPromoter.CanSubmitBachelorProposals = 
                newData.CanSubmitBachelorProposals;
            existingPromoter.CanSubmitMasterProposals =
                newData.CanSubmitMasterProposals;
            _context.Promoters.Update(existingPromoter);
            _context.SaveChangesAsync();
            return ServiceResult<Promoter>.Success(existingPromoter);
        }

        public IServiceResult<Promoter> Delete(Guid id)
        {
            Promoter promoter = _context.Promoters.Find(id);
            if(promoter == null)
            {
                return ServiceResult<Promoter>.Error(
                    "Promoter with the given id does not exist");
            }
            else
            {
                _context.Promoters.Remove(promoter);
                return ServiceResult<Promoter>.Success(promoter);
            }
        }

        public IServiceResult<Promoter> Create(PromoterRegistration registration)
        {
            if (EmailExists(registration.Email))
            {
                return ServiceResult<Promoter>.Error("Email already taken");
            }

            User user = CreateUser(registration.Email, registration.Password);
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
            else
            {
                return false;
            }
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

        private List<Proposal> GetProposalsWithIds(List<Guid> ids)
        {
            return _context
                .Proposals
                .Where(proposal => ids.Any(_ => _ == proposal.Id))
                .ToList();
        }
    }
}
