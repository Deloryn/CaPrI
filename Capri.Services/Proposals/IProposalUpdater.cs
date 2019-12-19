using System;
using System.Threading.Tasks;
using Capri.Web.ViewModels.Proposal;

namespace Capri.Services.Proposals
{
    public interface IProposalUpdater
    {
        Task<IServiceResult<ProposalView>> Update(Guid id, ProposalRegistration inputData);
    }
}
