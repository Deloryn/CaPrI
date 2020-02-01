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
            var indexNumbers = registration.Students;
            if(indexNumbers == null)
            {
                return ServiceResult<bool>.Success(true);
            }

            var numOfStudents = indexNumbers.Count();
            if(numOfStudents > registration.MaxNumberOfStudents)
            {
                return ServiceResult<bool>.Error("The number of students exceeds the maximal number");
            }
            if(numOfStudents != indexNumbers.Distinct().Count())
            {
                return ServiceResult<bool>.Error("Some of the given student index numbers are the same");
            }

            foreach(var indexNumber in indexNumbers)
            {
                var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == indexNumber);
                if(student == null)
                {
                    return ServiceResult<bool>.Error($"The student with index number {indexNumber} does not exist");
                }
                if(student.StudyLevel != registration.Level)
                {
                    return ServiceResult<bool>.Error($"The student with index number {indexNumber} does not match to the given study level");
                }
                if(student.StudyMode != registration.Mode)
                {
                    return ServiceResult<bool>.Error($"The student with index number {indexNumber} does not match to the given study mode");
                }
            }
            return ServiceResult<bool>.Success(true);
        }
    }
}