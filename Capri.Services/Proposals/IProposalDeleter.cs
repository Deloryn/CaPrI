using System;
using System.Threading.Tasks;
using Capri.Web.ViewModels.Proposal;

namespace Capri.Services.Proposals
{
    public interface IProposalDeleter
    {
        Task<IServiceResult<ProposalView>> Delete(Guid id);
    }
}
