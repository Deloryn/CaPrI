using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Capri.Database;
using Capri.Services.Users;
using Capri.Web.ViewModels.Proposal;

namespace Capri.Services.Proposals
{
    public class ProposalUpdater : IProposalUpdater
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserGetter _userGetter;
        private readonly ISubmittedProposalGetter _submittedProposalGetter;

        public ProposalUpdater(ISqlDbContext context, IMapper mapper, IUserGetter userGetter, ISubmittedProposalGetter submittedProposalGetter)
        {
            _context = context;
            _mapper = mapper;
            _userGetter = userGetter;
            _submittedProposalGetter = submittedProposalGetter;
        }
        public async Task<IServiceResult<ProposalView>> Update(
            Guid id, 
            ProposalRegistration inputData)
        {
            var result = await _userGetter.GetCurrentUser();
            if(!result.Successful())
            {
                var errors = result.GetAggregatedErrors();
                return ServiceResult<ProposalView>.Error(errors);
            }
            
            var currentUser = result.Body();
            var promoter = 
                await _context
                .Promoters
                .Include(p => p.Proposals)
                .FirstOrDefaultAsync(p => p.UserId == currentUser.Id);

            if(promoter == null)
            {
                return ServiceResult<ProposalView>.Error("The current user has no associated promoter");
            }
            
            var proposal = promoter.Proposals.FirstOrDefault(p => p.Id == id);

            if (proposal == null)
            {
                return ServiceResult<ProposalView>.Error("This promoter has no proposal with the given id.");
            }

            proposal = _mapper.Map(inputData, proposal);

            _context.Proposals.Update(proposal);
            await _context.SaveChangesAsync();

            var proposalView = _mapper.Map<ProposalView>(proposal);
            return ServiceResult<ProposalView>.Success(proposalView);
        }
    }
}
