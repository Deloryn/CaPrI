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

        public async Task<IServiceResult<ProposalViewModel>> Create(
            ProposalRegistration inputData)
        {
            var result = await _userGetter.GetCurrentUser();
            if(!result.Successful())
            {
                var errors = result.GetAggregatedErrors();
                return ServiceResult<ProposalViewModel>.Error(errors);
            }

            var currentUser = result.Body();
            var promoter = 
                await _context
                .Promoters
                .Include(p => p.Proposals)
                .FirstOrDefaultAsync(p => p.UserId == currentUser.Id);

            if(promoter == null)
            {
                return ServiceResult<ProposalViewModel>.Error("The current user has no associated promoter");
            }

            if(!HasPermissionToCreateProposal(promoter, inputData.Level))
            {
                return ServiceResult<ProposalViewModel>.Error("You are not allowed to create this type of proposal");
            }

            var proposal = _mapper.Map<Proposal>(inputData);
            proposal.Promoter = promoter;

            promoter.Proposals.Add(proposal);
            _context.Promoters.Update(promoter);

            await _context.Proposals.AddAsync(proposal);
            await _context.SaveChangesAsync();

            var proposalViewModel = _mapper.Map<ProposalViewModel>(proposal);

            return ServiceResult<ProposalViewModel>.Success(proposalViewModel);
        }

        private bool HasPermissionToCreateProposal(Promoter promoter, StudyLevel level)
        {
            switch(level)
            {
                case StudyLevel.Bachelor:
                    return HasPermissionToCreateBachelorProposal(promoter);
                case StudyLevel.Master:
                    return HasPermissionToCreateMasterProposal(promoter);
                default:
                    return false;
            }
        }

        private bool HasPermissionToCreateBachelorProposal(Promoter promoter)
        {
            var numOfSubmittedProposals = CountSubmittedProposals(promoter, StudyLevel.Bachelor);
            if (numOfSubmittedProposals < promoter.ExpectedNumberOfBachelorProposals) 
            {
                return true;
            }
            return false;
        }

        private bool HasPermissionToCreateMasterProposal(Promoter promoter)
        {
            var numOfSubmittedProposals = CountSubmittedProposals(promoter, StudyLevel.Master);
            if (numOfSubmittedProposals < promoter.ExpectedNumberOfMasterProposals) 
            {
                return true;
            }
            return false;
        }

        private int CountSubmittedProposals(Promoter promoter, StudyLevel level)
        {
            if (promoter == null)
            {
                return 0;
            }
            return promoter
                .Proposals
                .Count(p => p.Level == level);
        }
    }
}
