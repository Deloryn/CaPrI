using System;
using System.Collections.Generic;
using Capri.Database.Entities;

namespace Capri.Services.Proposals
{
    public interface IProposalInformer
    {
        IServiceResult<bool> NumOfStudentsExceedsTheMaximum(ICollection<Guid> students, int maxNumOfStudents);
        IServiceResult<ProposalStatus> CalculateProposalStatus(Proposal proposal);
    }
}