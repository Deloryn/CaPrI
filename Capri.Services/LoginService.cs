using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Capri.Database.Entities.Identity;
using Capri.Web.ViewModels.User;

namespace Capri.Services
{
    public class LoginService : ILoginService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ITokenGenerator _tokenGenerator;

        public LoginService(
            SignInManager<User> signInManager, 
            UserManager<User> userManager,
            ITokenGenerator tokenGenerator)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<IServiceResult<UserSecurityStamp>> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return ServiceResult<UserSecurityStamp>.Error("User not found");
            }

            var canSignIn = await _signInManager.CanSignInAsync(user);
            if(canSignIn)
            {
                var result = 
                    await _signInManager.PasswordSignInAsync(email, password, true, false);
                if(result.Succeeded)
                {
                    string token = _tokenGenerator.GenerateTokenFor(user);
                    user.SecurityStamp = token;
                    return ServiceResult<UserSecurityStamp>.Success(new UserSecurityStamp
                    {
                        Email = user.Email,
                        SecurityStamp = user.SecurityStamp
                    });
                }
            }
            return ServiceResult<UserSecurityStamp>.Error("User cannot sign in");
        }
    }
}
