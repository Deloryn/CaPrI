using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capri.Services.Proposals
{
    public interface ISubmittedProposalGetter
    {
        Task<IServiceResult<int>> Get(Guid id);
    }
}
