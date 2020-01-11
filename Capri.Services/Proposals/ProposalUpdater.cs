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
        private readonly IProposalStatusGetter _proposalStatusGetter;
        private readonly IStudentGroupValidator _studentGroupValidator;
        private readonly IStudentGetter _studentGetter;

        public ProposalUpdater(
            ISqlDbContext context, 
            IMapper mapper, 
            IUserGetter userGetter,
            ICourseGetter courseGetter,
            IProposalStatusGetter proposalStatusGetter,
            IStudentGroupValidator studentGroupValidator,
            IStudentGetter studentGetter)
        {
            _context = context;
            _mapper = mapper;
            _userGetter = userGetter;
            _courseGetter = courseGetter;
            _proposalStatusGetter = proposalStatusGetter;
            _studentGroupValidator = studentGroupValidator;
            _studentGetter = studentGetter;
        }
        
        public async Task<IServiceResult<ProposalViewModel>> Update(
            Guid id, 
            ProposalRegistration inputData)
        {
            var proposal = _context.Proposals.Include(p => p.Students).FirstOrDefault(p => p.Id == id);
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

            var studentsResult = await _studentGetter.GetMany(inputData.Students);
            if(!studentsResult.Successful())
            {
                return ServiceResult<ProposalViewModel>.Error(studentsResult.GetAggregatedErrors());
            }
            var newStudents = studentsResult.Body();

            var proposalStatusResult = _proposalStatusGetter.CalculateProposalStatus(newStudents, inputData.MaxNumberOfStudents);
            if(!proposalStatusResult.Successful())
            {
                return ServiceResult<ProposalViewModel>.Error(proposalStatusResult.GetAggregatedErrors());
            }
            var proposalStatus = proposalStatusResult.Body();

            var oldStudents = proposal.Students;
            foreach(var student in oldStudents)
            {
                student.ProposalId = null;
            }
            await _context.SaveChangesAsync();
            
            proposal = _mapper.Map(inputData, proposal);
            proposal.Students = newStudents;
            proposal.Status = proposalStatus;
            _context.Proposals.Update(proposal);
            await _context.SaveChangesAsync();

            var proposalViewModels = _mapper.Map<ProposalViewModel>(proposal);
            return ServiceResult<ProposalViewModel>.Success(proposalViewModels);
        }
    }
}
