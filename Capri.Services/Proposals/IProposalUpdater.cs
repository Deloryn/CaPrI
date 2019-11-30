using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Capri.Database.Entities;
using Capri.Database.Entities.Identity;
using Capri.Web.ViewModels.Proposal;

namespace Capri.Services.Proposals
{
    public interface IProposalUpdater
    {
        Task<IServiceResult<Proposal>> Update(Guid id, ProposalUpdate proposalUpdate);
    }
}
