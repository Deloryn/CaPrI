using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Capri.Database;
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
        private readonly IProposalNumberValidator _proposalNumberValidator;
        private readonly IProposalStatusGetter _proposalStatusGetter;
        private readonly IStudentGroupValidator _studentGroupValidator;
        private readonly IStudentGetter _studentGetter;

        public ProposalUpdater(
            ISqlDbContext context, 
            IMapper mapper, 
            IUserGetter userGetter,
            ICourseGetter courseGetter,
            IProposalNumberValidator proposalNumberValidator,
            IProposalStatusGetter proposalStatusGetter,
            IStudentGroupValidator studentGroupValidator,
            IStudentGetter studentGetter)
        {
            _context = context;
            _mapper = mapper;
            _userGetter = userGetter;
            _courseGetter = courseGetter;
            _proposalNumberValidator = proposalNumberValidator;
            _proposalStatusGetter = proposalStatusGetter;
            _studentGroupValidator = studentGroupValidator;
            _studentGetter = studentGetter;
        }
        
        public async Task<IServiceResult<ProposalViewModel>> Update(
            Guid id, 
            ProposalRegistration inputData)
        {
            var courseResult = await _courseGetter.Get(inputData.CourseId);
            if(!courseResult.Successful())
            {
                return ServiceResult<ProposalViewModel>.Error(courseResult.GetAggregatedErrors());
            }

            var numOfStudentsExceedsTheMaximumResult = _proposalNumberValidator
                .NumOfStudentsExceedsTheMaximum(inputData.Students, inputData.MaxNumberOfStudents);
            if(!numOfStudentsExceedsTheMaximumResult.Successful())
            {
                return ServiceResult<ProposalViewModel>.Error(numOfStudentsExceedsTheMaximumResult.GetAggregatedErrors());
            }

            var numOfStudentsExceedsTheMaximum = numOfStudentsExceedsTheMaximumResult.Body();
            if(numOfStudentsExceedsTheMaximum)
            {
                return ServiceResult<ProposalViewModel>.Error("The number of students exceeds the maximal number");
            }

            var studentGroupValidatorResult = await _studentGroupValidator.DoStudentsExist(inputData.Students);
            if(!studentGroupValidatorResult.Successful())
            {
                return ServiceResult<ProposalViewModel>.Error(studentGroupValidatorResult.GetAggregatedErrors());
            }

            var doStudentsExist = studentGroupValidatorResult.Body();
            if(!doStudentsExist)
            {
                return ServiceResult<ProposalViewModel>.Error("Some of the given students don't exist");
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
            
            var proposal = promoter.Proposals.FirstOrDefault(p => p.Id == id);

            if (proposal == null)
            {
                return ServiceResult<ProposalViewModel>.Error(
                    $"This promoter has no proposal with id {id}");
            }

            var studentsResult = await _studentGetter.GetMany(inputData.Students);
            if(!studentsResult.Successful())
            {
                return ServiceResult<ProposalViewModel>.Error(studentsResult.GetAggregatedErrors());
            }

            var students = studentsResult.Body();
            if(students.Any(s => s.ProposalId != null))
            {
                return ServiceResult<ProposalViewModel>.Error("Some of the students already have an assigned proposal");
            }

            proposal = _mapper.Map(inputData, proposal);
            proposal.Students = students;

            var proposalStatusResult = _proposalStatusGetter.CalculateProposalStatus(proposal);
            if(!proposalStatusResult.Successful())
            {
                return ServiceResult<ProposalViewModel>.Error(proposalStatusResult.GetAggregatedErrors());
            }

            var proposalStatus = proposalStatusResult.Body();
            proposal.Status = proposalStatus;

            _context.Proposals.Update(proposal);
            await _context.SaveChangesAsync();

            var proposalViewModels = _mapper.Map<ProposalViewModel>(proposal);
            return ServiceResult<ProposalViewModel>.Success(proposalViewModels);
        }
    }
}
