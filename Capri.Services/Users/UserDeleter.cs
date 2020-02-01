using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Capri.Database;
using Capri.Database.Entities.Identity;

namespace Capri.Services.Users
{
    public class UserDeleter : IUserDeleter
    {
        private readonly ISqlDbContext _context;
        private readonly UserManager<User> _userManager;

        public UserDeleter(
            ISqlDbContext context,
            UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IServiceResult<User>> Delete(int id)
        {
            var applicationUser = 
                await _context
                .Users
                .FirstOrDefaultAsync(u => u.Id == id);

            await _userManager.DeleteAsync(applicationUser);
            return ServiceResult<User>.Success(applicationUser);
        }
    }
}