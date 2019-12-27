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
        Task<IServiceResult<ProposalViewModel>> Get(Guid id);

        IServiceResult<IEnumerable<ProposalViewModel>> GetAll();

        IServiceResult<IQueryable<ProposalViewModel>> GetFiltered(SieveModel sieveModel);
    }
}
