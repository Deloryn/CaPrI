using System.Linq;
using Capri.Database.Entities;
using Sieve.Models;

namespace Capri.Services.Proposals
{
    public interface IProposalFilter
    {
        IServiceResult<IQueryable<Proposal>> Apply(
            SieveModel sieveModel, 
            IQueryable<Proposal> proposals);
    }
}