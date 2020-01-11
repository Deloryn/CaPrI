using System.Collections.Generic;
using Capri.Database.Entities;

namespace Capri.Services.Proposals
{
    public interface IProposalStatusGetter
    {
        IServiceResult<ProposalStatus> CalculateProposalStatus(ICollection<Student> students, int maxNumberOfStudents);
    }
}