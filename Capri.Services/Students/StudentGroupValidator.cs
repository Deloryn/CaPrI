using System.Linq;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Capri.Database;
using Capri.Web.ViewModels.Proposal;

namespace Capri.Services.Students
{
    public class StudentGroupValidator : IStudentGroupValidator
    {
        private readonly ISqlDbContext _context;
        private readonly IStudentGetter _studentGetter;

        public StudentGroupValidator(
            ISqlDbContext context,
            IStudentGetter studentGetter
        )
        {
            _context = context;
            _studentGetter = studentGetter;
        }

        public async Task<IServiceResult<bool>> IsStudentGroupValidFor(
            ProposalRegistration registration)
        {
            var studentIds = registration.Students;
            if(studentIds == null)
            {
                return ServiceResult<bool>.Success(true);
            }

            var numOfStudents = studentIds.Count();
            if(numOfStudents > registration.MaxNumberOfStudents)
            {
                return ServiceResult<bool>.Error("The number of students exceeds the maximal number");
            }
            if(numOfStudents != studentIds.Distinct().Count())
            {
                return ServiceResult<bool>.Error("Some of the given student IDs are the same");
            }

            foreach(var id in studentIds)
            {
                var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
                if(student == null)
                {
                    return ServiceResult<bool>.Error($"The student with id {id} does not exist");
                }
                if(student.StudyLevel != registration.Level)
                {
                    return ServiceResult<bool>.Error($"The student with id {id} does not match to the given study level");
                }
                if(student.StudyMode != registration.Mode)
                {
                    return ServiceResult<bool>.Error($"The student with id {id} does not match to the given study mode");
                }
                if(student.ProposalId != null && student.ProposalId != Guid.Empty)
                {
                    return ServiceResult<bool>.Error($"The student with id {id} is already assigned to a proposal with id {student.ProposalId}");
                }
            }
            return ServiceResult<bool>.Success(true);
        }
    }
}