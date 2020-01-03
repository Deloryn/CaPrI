using System;
using System.Collections.Generic;
using Capri.Database.Entities;

namespace Capri.Services.Proposals
{
    public interface IProposalNumberValidator
    {
        IServiceResult<bool> NumOfStudentsExceedsTheMaximum(ICollection<Guid> students, int maxNumOfStudents);
        IServiceResult<ProposalStatus> CalculateProposalStatus(Proposal proposal);
    }
}