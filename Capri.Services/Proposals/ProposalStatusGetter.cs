using System.Collections.Generic;
using System.Linq;
using Capri.Database.Entities;

namespace Capri.Services.Proposals
{
    public class ProposalStatusGetter : IProposalStatusGetter
    {
        public IServiceResult<ProposalStatus> CalculateProposalStatus(ICollection<Student> students, int maxNumberOfStudents)
        {
            if(students == null)
            {
                return ServiceResult<ProposalStatus>.Success(ProposalStatus.Free);
            }
            else if(students.Count() < maxNumberOfStudents)
            {
                return ServiceResult<ProposalStatus>.Success(ProposalStatus.PartiallyTaken);
            }
            else if(students.Count() == maxNumberOfStudents)
            {
                return ServiceResult<ProposalStatus>.Success(ProposalStatus.Taken);
            }
            else
            {
                return ServiceResult<ProposalStatus>.Error(
                    "The number of the given students exceeds the max number of students"
                );
            }
        }
    }
}