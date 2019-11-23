using System.Linq;
using Sieve.Services;
using Sieve.Models;
using Capri.Database.Entities;

namespace Capri.Services.Proposals
{
    public class ProposalFilter : IProposalFilter
    {
        private readonly ISieveProcessor _sieveProcessor;
        public ProposalFilter(ISieveProcessor sieveProcessor)
        {
            _sieveProcessor = sieveProcessor;
        }

        public IServiceResult<IQueryable<Proposal>> Apply(
            SieveModel sieveModel, 
            IQueryable<Proposal> proposals)
        {
            var filtered = _sieveProcessor.Apply(sieveModel, proposals);
            return ServiceResult<IQueryable<Proposal>>.Success(filtered);
        }
    }
}