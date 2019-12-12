using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Capri.Database.Entities.Identity;

namespace Capri.Services.Users
{
    public class UserGetter : IUserGetter
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserGetter(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IServiceResult<User>> GetCurrentUser()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            if(user == null)
            {
                return ServiceResult<User>.Error("No current user found");
            }
            return ServiceResult<User>.Success(user);
        }
    }
}
