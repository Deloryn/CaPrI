using Capri.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capri.Services.Proposals
{
    public class SubmittedProposalGetter : ISubmittedProposalGetter
    {
        private readonly ISqlDbContext _context;

        public SubmittedProposalGetter(ISqlDbContext context)
        {
            _context = context;
        }

        public async Task<IServiceResult<int>> GetBachelorProposalNumber(Guid promoterId)
        {
            var promoter = await _context.Promoters
                .Include(p => p.Proposals)
                .FirstOrDefaultAsync(p => p.Id == promoterId);

            if (promoter == null)
            {
                return ServiceResult<int>.Success(0);
            }

            var count = promoter.Proposals
                .Where(p => p.Level == Database.Entities.StudyLevel.Bachelor)
                .Count();
            return ServiceResult<int>.Success(count);
        }

        public async Task<IServiceResult<int>> GetMasterProposalNumber(Guid promoterId)
        {
            var promoter = await _context.Promoters
                .Include(p => p.Proposals)
                .FirstOrDefaultAsync(p => p.Id == promoterId);

            if (promoter == null)
            {
                return ServiceResult<int>.Success(0);
            }

            var count = promoter.Proposals
                .Where(p => p.Level == Database.Entities.StudyLevel.Master)
                .Count();
            return ServiceResult<int>.Success(count);
        }

    }
}
