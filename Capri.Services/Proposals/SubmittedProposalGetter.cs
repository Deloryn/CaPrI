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

        public async Task<IServiceResult<int>> Get(Guid id)
        {
            var promoter = await _context.Promoters
                .Include(p => p.Proposals)
                .FirstOrDefaultAsync(p => p.UserId == id);
                
            if (promoter != null) {
                if (promoter.Proposals == null)
                {
                    return ServiceResult<int>.Success(0);
                }
                return ServiceResult<int>.Success(promoter.Proposals.Count);
            }

            var student = await _context.Students.FirstOrDefaultAsync(s => s.UserId == id);
            if (student != null)
            {
                var proposal = await _context.Proposals.FirstOrDefaultAsync(p => p.Students.Contains(student));
                if (proposal != null)
                {
                    return ServiceResult<int>.Success(1);
                }
            }

            return ServiceResult<int>.Success(0);
        }
    }
}
