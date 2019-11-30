using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Capri.Database;
using Capri.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Capri.Services.Proposals
{
    public class ProposalDeleter : IProposalDeleter
    {
        private readonly ISqlDbContext _context;
        private readonly IPromoterGetter _promoterGetter;

        public ProposalDeleter(ISqlDbContext context, IPromoterGetter promoterGetter)
        {
            _context = context;
            _promoterGetter = promoterGetter;
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
