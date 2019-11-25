using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using Capri.Database;
using Capri.Database.Entities;

namespace Capri.Services.Proposals
{
    public class ProposalGetter : IProposalGetter
    {
        private readonly ISqlDbContext _context;
        private readonly ISieveProcessor _sieveProcessor;

        public ProposalGetter(
            ISqlDbContext context, 
            ISieveProcessor sieveProcessor)
        {
            _context = context;
            _sieveProcessor = sieveProcessor;
        }

        public async Task<IServiceResult<Proposal>> Get(Guid id)
        {
            var proposal = await _context.Proposals.FirstOrDefaultAsync(p => p.Id == id);

            return ServiceResult<Proposal>.Success(proposal);
        }

        public IServiceResult<IEnumerable<Proposal>> GetAll()
        {
            var proposals = _context.Proposals;

            return ServiceResult<IEnumerable<Proposal>>.Success(proposals);
        }

        public IServiceResult<IQueryable<Proposal>> GetFiltered (SieveModel sieveModel)
        {
            var proposals = _context.Proposals.AsQueryable();
            var filtered = _sieveProcessor.Apply(sieveModel, proposals);
            return ServiceResult<IQueryable<Proposal>>.Success(filtered);
        }
    }
}
