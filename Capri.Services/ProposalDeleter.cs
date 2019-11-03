using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Capri.Database;
using Capri.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Capri.Services
{
    public class ProposalDeleter : IProposalDeleter
    {
        private readonly ISqlDbContext _context;

        public ProposalDeleter(ISqlDbContext context)
        {
            _context = context;
        }
        public async Task<IServiceResult<Proposal>> Delete(Guid id)
        {
            var proposal = await _context.Proposals.FirstOrDefaultAsync(p => p.Id == id);

            if (proposal == null)
            {
                return ServiceResult<Proposal>.Error("Proposal with given id does not exist.");
            }

            _context.Proposals.Remove(proposal);
            await _context.SaveChangesAsync();

            return ServiceResult<Proposal>.Success(proposal);
        }
    }
}
