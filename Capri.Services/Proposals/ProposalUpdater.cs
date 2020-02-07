using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Capri.Database;
using Capri.Database.Entities;
using Capri.Services.Users;
using Capri.Services.Courses;
using Capri.Services.Students;
using Capri.Web.ViewModels.Proposal;

namespace Capri.Services.Proposals
{
    public class ProposalUpdater : IProposalUpdater
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserGetter _userGetter;
        private readonly ICourseGetter _courseGetter;
        private readonly IStudentGetter _studentGetter;

        public ProposalUpdater(
            ISqlDbContext context, 
            IMapper mapper, 
            IUserGetter userGetter,
            ICourseGetter courseGetter,
            IStudentGetter studentGetter)
        {
            _context = context;
            _mapper = mapper;
            _userGetter = userGetter;
            _courseGetter = courseGetter;
            _studentGetter = studentGetter;
        }
        
        public async Task<IServiceResult<ProposalViewModel>> Update(
            int id, 
            ProposalRegistration inputData)
        {
            var proposal = _context.Proposals.FirstOrDefault(p => p.Id == id);
            if(proposal == null)
            {
                return ServiceResult<ProposalViewModel>.Error(
                    $"Proposal with id {id} does not exist"
                );
            }

            var courseResult = await _courseGetter.Get(inputData.CourseId);
            if(!courseResult.Successful())
            {
                return ServiceResult<ProposalViewModel>.Error(courseResult.GetAggregatedErrors());
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
                    $"Promoter with id {promoter.Id} has no proposal with id {id}"
                );
            }
            
            proposal = _mapper.Map(inputData, proposal);
            if(proposal.Status == ProposalStatus.Overloaded)
            {
                return ServiceResult<ProposalViewModel>.Error("The number of students exceeds the maximal number");
            }
            _context.Proposals.Update(proposal);
            await _context.SaveChangesAsync();

            var proposalViewModels = _mapper.Map<ProposalViewModel>(proposal);
            return ServiceResult<ProposalViewModel>.Success(proposalViewModels);
        }
    }
}
