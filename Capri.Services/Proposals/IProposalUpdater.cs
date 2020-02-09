using System;
using System.Threading.Tasks;
using Capri.Web.ViewModels.Proposal;

namespace Capri.Services.Proposals
{
    public interface IProposalUpdater
    {
        Task<IServiceResult<ProposalViewModel>> Update(int id, ProposalRegistration inputData);
    }
}
