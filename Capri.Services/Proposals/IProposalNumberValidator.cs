using System;
using System.Collections.Generic;

namespace Capri.Services.Proposals
{
    public interface IProposalNumberValidator
    {
        IServiceResult<bool> NumOfStudentsExceedsTheMaximum(ICollection<Guid> students, int maxNumOfStudents);
    }
}