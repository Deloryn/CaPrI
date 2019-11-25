using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capri.Services.Proposals
{
    public interface ISubmittedProposalGetter
    {
        Task<IServiceResult<int>> GetProposalNumber(Guid id);
        Task<IServiceResult<int>> GetBachelorProposalNumber(Guid promoterId);
        Task<IServiceResult<int>> GetMasterProposalNumber(Guid promoterId);
    }
}
