using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Capri.Database;
using Capri.Database.Entities;

namespace Capri.Services.Proposals
{
    public class SubmittedProposalGetter : ISubmittedProposalGetter
    {
        private readonly ISqlDbContext _context;

        public SubmittedProposalGetter(ISqlDbContext context)
        {
            _context = context;
        }

        public async Task<IServiceResult<int>> CountSubmittedProposals(
            int promoterId, 
            StudyLevel level)
        {
            var promoter = await _context.Promoters
                .Include(p => p.Proposals)
                .FirstOrDefaultAsync(p => p.Id == promoterId);

            if (promoter == null)
            {
                return ServiceResult<int>.Error(
                    $"There is no promoter with id {promoterId}");
            }

            var count = promoter.Proposals
                .Where(p => p.Level == level)
                .Count();

            return ServiceResult<int>.Success(count);
        }
    }
}
