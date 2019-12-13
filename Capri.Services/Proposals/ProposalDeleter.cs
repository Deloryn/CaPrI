using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Capri.Database;
using Capri.Database.Entities;
using Capri.Services.Promoters;
using Capri.Services.Users;

namespace Capri.Services.Proposals
{
    public class ProposalDeleter : IProposalDeleter
    {
        private readonly ISqlDbContext _context;
        private readonly IPromoterGetter _promoterGetter;
        private readonly IUserGetter _userGetter;

        public ProposalDeleter(
            ISqlDbContext context, 
            IPromoterGetter promoterGetter,
            IUserGetter userGetter)
        {
            _context = context;
            _promoterGetter = promoterGetter;
            _userGetter = userGetter;
        }

        public async Task<IServiceResult<Proposal>> Delete(Guid id)
        {
            var result = await _userGetter.GetCurrentUser();
            if(!result.Successful())
            {
                var errors = result.GetAggregatedErrors();
                return ServiceResult<Proposal>.Error(errors);
            }
            
            var currentUser = result.Body();
            var promoter = 
                await _context
                .Promoters
                .Include(p => p.Proposals)
                .FirstOrDefaultAsync(p => p.UserId == currentUser.Id);

            if(promoter == null)
            {
                return ServiceResult<Proposal>.Error("The current user has no associated promoter");
            }
            
            var proposal = promoter.Proposals.FirstOrDefault(p => p.Id == id);

            if (proposal == null)
            {
                return ServiceResult<Proposal>.Error("This promoter has no proposal with the given id.");
            }

            _context.Proposals.Remove(proposal);
            await _context.SaveChangesAsync();

            return ServiceResult<Proposal>.Success(proposal);
        }
    }
}
