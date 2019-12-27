using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Capri.Database;
using Capri.Database.Entities;
using Capri.Database.Entities.Identity;

namespace Capri.Services.Promoters
{
    public class PromoterDeleter : IPromoterDeleter
    {
        private readonly ISqlDbContext _context;
        private readonly UserManager<User> _userManager;

        public PromoterDeleter(
            ISqlDbContext context,
            UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
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
                    $"Promoter with id {id} does not exist");
            }

            var applicationUser = 
                await _context
                .Users
                .FirstOrDefaultAsync(u => u.Id == promoter.UserId);

            _context.Promoters.Remove(promoter);

            await _userManager.DeleteAsync(applicationUser);
            _context.Users.Remove(applicationUser);

            await _context.SaveChangesAsync();

            return ServiceResult<Promoter>.Success(promoter);
        }
    }
}
