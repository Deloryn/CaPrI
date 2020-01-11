using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Capri.Database;
using Capri.Database.Entities;
using Capri.Services.Users;
using Capri.Services.Students;
using Capri.Services.Settings;
using Capri.Services.Courses;
using Capri.Web.ViewModels.Proposal;

namespace Capri.Services.Proposals
{
    public class ProposalCreator : IProposalCreator
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
        private readonly ISystemSettingsGetter _systemSettingsGetter;
        private readonly IUserGetter _userGetter;
        private readonly ICourseGetter _courseGetter;
        private readonly ISubmittedProposalGetter _submittedProposalGetter;
        private readonly IProposalStatusGetter _proposalStatusGetter;
        private readonly IStudentGroupValidator _studentGroupValidator;
        private readonly IStudentGetter _studentGetter;

        public ProposalCreator(
            ISqlDbContext context, 
            IMapper mapper,
            ISystemSettingsGetter systemSettingsGetter,
            IUserGetter userGetter,
            ICourseGetter courseGetter,
            ISubmittedProposalGetter submittedProposalGetter,
            IProposalStatusGetter proposalStatusGetter,
            IStudentGroupValidator studentGroupValidator,
            IStudentGetter studentGetter)
        {
            _context = context;
            _mapper = mapper;
            _systemSettingsGetter = systemSettingsGetter;
            _userGetter = userGetter;
            _courseGetter = courseGetter;
            _submittedProposalGetter = submittedProposalGetter;
            _proposalStatusGetter = proposalStatusGetter;
            _studentGroupValidator = studentGroupValidator;
            _studentGetter = studentGetter;
        }

        public async Task<IServiceResult<ProposalViewModel>> Create(
            ProposalRegistration inputData)
        {
            var courseResult = await _courseGetter.Get(inputData.CourseId);
            if(!courseResult.Successful())
            {
                return ServiceResult<ProposalViewModel>.Error(courseResult.GetAggregatedErrors());
            }

            var studentGroupValidatorResult = await _studentGroupValidator.IsStudentGroupValidFor(inputData);
            if(!studentGroupValidatorResult.Successful())
            {
                return ServiceResult<ProposalViewModel>.Error(studentGroupValidatorResult.GetAggregatedErrors());
            }

            var isStudentGroupValid = studentGroupValidatorResult.Body();
            if(!isStudentGroupValid)
            {
                return ServiceResult<ProposalViewModel>.Error("The given students are not valid");
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

            var studentsResult = await _studentGetter.GetMany(inputData.Students);
            if(!studentsResult.Successful())
            {
                return ServiceResult<ProposalViewModel>.Error(studentsResult.GetAggregatedErrors());
            }
            var students = studentsResult.Body();

            var proposalStatusResult = _proposalStatusGetter.CalculateProposalStatus(students, inputData.MaxNumberOfStudents);
            if(!proposalStatusResult.Successful())
            {
                return ServiceResult<ProposalViewModel>.Error(proposalStatusResult.GetAggregatedErrors());
            }
            var proposalStatus = proposalStatusResult.Body();

            var proposal = _mapper.Map<Proposal>(inputData);
            proposal.Students = students;
            proposal.Status = proposalStatus;
            SetStartDate(proposal);
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

        private void SetStartDate(Proposal proposal)
        {
            var level = proposal.Level;
            if(level == StudyLevel.Bachelor)
            {
                var startingDate = _systemSettingsGetter.GetSystemSettings().BachelorThesisStartDate;
                proposal.StartingDate = startingDate;
            }
            else
            {
                var startingDate = _systemSettingsGetter.GetSystemSettings().MasterThesisStartDate;
                proposal.StartingDate = startingDate;
            }
        }
    }
}
