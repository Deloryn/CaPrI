using System;
using System.Threading.Tasks;
using Capri.Database.Entities;
using Capri.Web.ViewModels.Proposal;

namespace Capri.Services.Proposals
{
    public interface IProposalUpdater
    {
        Task<IServiceResult<Proposal>> Update(Guid id, ProposalUpdate proposalUpdate);
    }
}
