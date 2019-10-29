using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capri.Database;
using Capri.Database.Entities;
using Capri.Database.Entities.Identity;
using Capri.Web.ViewModels.Promoter;

namespace Capri.Services
{
    public class PromoterUpdater : IPromoterUpdater
    {
        private readonly ISqlDbContext _context;

        public PromoterUpdater(ISqlDbContext context)
        {
            _context = context;
        }

        public IServiceResult<Promoter> Update(PromoterUpdate newData)
        {
            Promoter existingPromoter = _context.Promoters.Find(newData.Id);
            if (existingPromoter == null)
            {
                return ServiceResult<Promoter>.Error(
                    "Promoter with the given does not exist");
            }

            User existingUser = _context.Users.Find(newData.UserId);
            if (existingUser == null)
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

        private List<Proposal> GetProposalsWithIds(List<Guid> ids)
        {
            return _context
                .Proposals
                .Where(proposal => ids.Any(_ => _ == proposal.Id))
                .ToList();
        }
    }
}
