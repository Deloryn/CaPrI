using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sieve.Models;
using Capri.Web.ViewModels.Proposal;

namespace Capri.Services.Proposals
{
    public interface IProposalGetter
    {
        Task<IServiceResult<ProposalView>> Get(Guid id);

        IServiceResult<IEnumerable<ProposalView>> GetAll();

        IServiceResult<IQueryable<ProposalView>> GetFiltered(SieveModel sieveModel);
    }
}
