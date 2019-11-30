using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capri.Database.Entities;
using Sieve.Models;

namespace Capri.Services.Proposals
{
    public interface IProposalGetter
    {
        Task<IServiceResult<Proposal>> Get(Guid id);

        IServiceResult<IEnumerable<Proposal>> GetAll();

        IServiceResult<IQueryable<Proposal>> GetFiltered(SieveModel sieveModel);
    }
}
