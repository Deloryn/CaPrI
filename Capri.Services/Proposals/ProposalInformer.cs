using System;
using System.Linq;
using System.Collections.Generic;
using Capri.Database.Entities;

namespace Capri.Services.Proposals
{
    public class ProposalInformer : IProposalInformer
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

        public IServiceResult<ProposalStatus> CalculateProposalStatus(Proposal proposal)
        {
            if(proposal.Students == null)
            {
                return ServiceResult<ProposalStatus>.Success(ProposalStatus.Free);
            }
            else if(proposal.Students.Count() < proposal.MaxNumberOfStudents)
            {
                return ServiceResult<ProposalStatus>.Success(ProposalStatus.PartiallyTaken);
            }
            else
            {
                return ServiceResult<ProposalStatus>.Success(ProposalStatus.Taken);
            }
        }
    }
}