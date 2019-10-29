using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IServiceResult<Promoter>> Update(PromoterUpdate newData)
        {
            var existingPromoter = 
                await _context
                .Promoters
                .FirstOrDefaultAsync(_ => _.Id == newData.Id);

            if (existingPromoter == null)
            {
                return ServiceResult<Promoter>.Error(
                    "Promoter with the given does not exist");
            }

            var existingUser = 
                await _context
                .Users
                .FirstOrDefaultAsync(_ => _.Id == newData.UserId);

            if (existingUser == null)
            {
                return ServiceResult<Promoter>.Error(
                    "User with the given id does not exist");
            }

            existingPromoter.UserId = newData.UserId;
            existingPromoter.Proposals = 
                GetProposalsWithIds(newData.ProposalsIds)
                .ToList();
            existingPromoter.CanSubmitBachelorProposals =
                newData.CanSubmitBachelorProposals;
            existingPromoter.CanSubmitMasterProposals =
                newData.CanSubmitMasterProposals;

            _context.Promoters.Update(existingPromoter);
            await _context.SaveChangesAsync();

            return ServiceResult<Promoter>.Success(existingPromoter);
        }

        private IEnumerable<Proposal> GetProposalsWithIds(IEnumerable<Guid> ids)
        {
            return _context
                .Proposals
                .Where(proposal => ids.Any(_ => _ == proposal.Id));
        }
    }
}
