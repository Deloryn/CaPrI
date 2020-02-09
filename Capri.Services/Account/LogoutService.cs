using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Capri.Database.Entities.Identity;

namespace Capri.Services.Account
{
    public class LogoutService : ILogoutService
    {
        private readonly SignInManager<User> _signInManager;

        public LogoutService(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}