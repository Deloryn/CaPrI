using System.Linq;
using Capri.Database.Entities;

namespace Capri.Services.Proposals
{
    public class ProposalStatusGetter : IProposalStatusGetter
    {
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