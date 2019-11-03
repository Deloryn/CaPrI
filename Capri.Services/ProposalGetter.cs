using Capri.Database;
using Capri.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capri.Services
{
    public class ProposalGetter : IProposalGetter
    {
        private readonly ISqlDbContext _context;

        public ProposalGetter(ISqlDbContext context)
        {
            _context = context;
        }

        public async Task<IServiceResult<Proposal>> Get(Guid id)
        {
            var proposal = await _context.Proposals.FirstOrDefaultAsync(p => p.Id == id);

            if (proposal == null)
            {
                return ServiceResult<Proposal>.Error("Proposal with given id does not exist.");
            }

            return ServiceResult<Proposal>.Success(proposal);
        }

        public IServiceResult<IEnumerable<Proposal>> GetAll()
        {
            var proposals = _context.Proposals;

            return ServiceResult<IEnumerable<Proposal>>.Success(proposals);
        }
    }
}
