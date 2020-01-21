using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Capri.Database;
using Capri.Services.Promoters;
using Capri.Services.Users;
using Capri.Web.ViewModels.Proposal;

namespace Capri.Services.Proposals
{
    public class ProposalDeleter : IProposalDeleter
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPromoterGetter _promoterGetter;
        private readonly IUserGetter _userGetter;

        public ProposalDeleter(
            ISqlDbContext context, 
            IMapper mapper,
            IPromoterGetter promoterGetter,
            IUserGetter userGetter)
        {
            _context = context;
            _mapper = mapper;
            _promoterGetter = promoterGetter;
            _userGetter = userGetter;
        }

        public async Task<IServiceResult<ProposalViewModel>> Delete(Guid id)
        {
            var proposal = await _context
                .Proposals
                .Include(p => p.Students)
                .FirstOrDefaultAsync(p => p.Id == id);

            if(proposal == null)
            {
                return ServiceResult<ProposalViewModel>.Error(
                    $"Proposal with id {id} does not exist"
                );
            }

            var userResult = await _userGetter.GetCurrentUser();
            if(!userResult.Successful())
            {
                var errors = userResult.GetAggregatedErrors();
                return ServiceResult<ProposalViewModel>.Error(errors);
            }
            
            var currentUser = userResult.Body();
            var promoter = 
                await _context
                .Promoters
                .FirstOrDefaultAsync(p => p.UserId == currentUser.Id);

            if(promoter == null)
            {
                return ServiceResult<ProposalViewModel>.Error("The current user has no associated promoter");
            }

            if (proposal.PromoterId != promoter.Id)
            {
                return ServiceResult<ProposalViewModel>.Error(
                    $"Promoter with id {promoter.Id} has no proposal with id {id}");
            }

            var proposalViewModel = _mapper.Map<ProposalViewModel>(proposal);
            
            _context.Proposals.Remove(proposal);
            await _context.SaveChangesAsync();

            return ServiceResult<ProposalViewModel>.Success(proposalViewModel);
        }
    }
}
