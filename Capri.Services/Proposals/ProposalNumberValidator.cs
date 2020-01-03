using System;
using System.Linq;
using System.Collections.Generic;

namespace Capri.Services.Proposals
{
    public class ProposalNumberValidator : IProposalNumberValidator
    {
        public IServiceResult<bool> NumOfStudentsExceedsTheMaximum(ICollection<Guid> students, int maxNumOfStudents)
        {
            if(students == null)
            {
                return ServiceResult<bool>.Success(false);
            }
            else if(students.Count() <= maxNumOfStudents)
            {
                return ServiceResult<bool>.Success(false);
            }
            return ServiceResult<bool>.Success(true);
        }
    }
}