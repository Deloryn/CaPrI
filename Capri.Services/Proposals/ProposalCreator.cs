using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Capri.Database;
using Capri.Database.Entities;
using Capri.Services.Users;
using Capri.Web.ViewModels.Proposal;

namespace Capri.Services.Proposals
{
    public class ProposalCreator : IProposalCreator
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserGetter _userGetter;
        private readonly ISubmittedProposalGetter _submittedProposalGetter;

        public ProposalCreator(
            ISqlDbContext context, 
            IMapper mapper, 
            IUserGetter userGetter, 
            ISubmittedProposalGetter submittedProposalGetter)
        {
            _context = context;
            _mapper = mapper;
            _userGetter = userGetter;
            _submittedProposalGetter = submittedProposalGetter;
        }

        public async Task<IServiceResult<ProposalView>> Create(
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

            if(!HasPermissionToCreateProposal(promoter, inputData.Level))
            {
                return ServiceResult<ProposalView>.Error("You are not allowed to create this type of proposal");
            }

            var proposal = _mapper.Map<Proposal>(inputData);
            proposal.Promoter = promoter;

            promoter.Proposals.Add(proposal);
            _context.Promoters.Update(promoter);

            await _context.Proposals.AddAsync(proposal);
            await _context.SaveChangesAsync();

            var proposalView = _mapper.Map<ProposalView>(proposal);

            return ServiceResult<ProposalView>.Success(proposalView);
        }

        private bool HasPermissionToCreateProposal(Promoter promoter, StudyLevel level)
        {
            var numOfSubmittedProposals = CountSubmittedProposals(promoter, level);
            switch(level)
            {
                case StudyLevel.Bachelor:
                    if (numOfSubmittedProposals < promoter.ExpectedNumberOfBachelorProposals) 
                    {
                        return true;
                    }
                    return false;
                case StudyLevel.Master:
                    if(numOfSubmittedProposals < promoter.ExpectedNumberOfMasterProposals)
                    {
                        return true;
                    }
                    return false;
                default:
                    return false;
            }
        }

        private int CountSubmittedProposals(Promoter promoter, StudyLevel level)
        {
            if (promoter == null)
            {
                return 0;
            }
            return promoter
                .Proposals
                .Where(p => p.Level == level)
                .Count();
        }
    }
}
