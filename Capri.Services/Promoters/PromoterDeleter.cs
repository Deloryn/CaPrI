using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Capri.Database;
using Capri.Database.Entities;

namespace Capri.Services.Promoters
{
    public class PromoterDeleter : IPromoterDeleter
    {
        private readonly ISqlDbContext _context;

        public PromoterDeleter(ISqlDbContext context)
        {
            _context = context;
        }

        public async Task<IServiceResult<Promoter>> Delete(Guid id)
        {
            var promoter = 
                await _context
                .Promoters
                .FirstOrDefaultAsync(p => p.Id == id);

            if(promoter == null)
            {
                return ServiceResult<Promoter>.Error(
                    "Promoter with the given id does not exist");
            }

            var applicationUser = 
                await _context
                .Users
                .FirstOrDefaultAsync(u => u.Id == promoter.UserId);

            _context.Promoters.Remove(promoter);
            _context.Users.Remove(applicationUser);

            await _context.SaveChangesAsync();

            return ServiceResult<Promoter>.Success(promoter);
        }
    }
}
