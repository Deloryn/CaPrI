using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using Capri.Database;
using Capri.Database.Entities.Identity;
using Capri.Web.Services.Settings;
using Capri.Web.ViewModels.User;

namespace Capri.Web.Services
{
    public class LoginService : ILoginService
    {
        private readonly SignInManager<User> _signInManager;

        private readonly UserManager<User> _userManager;

        private readonly JwtAuthorizationDetails _jwtAuthorizationDetails;

        public LoginService(
            SignInManager<User> signInManager, 
            UserManager<User> userManager, 
            IOptions<JwtAuthorizationDetails> jwtAuthDetailsOptions)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtAuthorizationDetails = jwtAuthDetailsOptions.Value;
        }

        public async Task<IServiceResult> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return ServiceResult.UserNotFound();
            }

            var canSignIn = await _signInManager.CanSignInAsync(user);
            if(canSignIn)
            {
                var result = 
                    await _signInManager.PasswordSignInAsync(email, password, true, false);
                if(result.Succeeded)
                {
                    string token = GenerateTokenFor(user);
                    user.SecurityStamp = token;
                    return ServiceResult.Of(new UserSecurityStamp
                    {
                        Email = user.Email,
                        SecurityStamp = user.SecurityStamp
                    });
                }
            }
            return ServiceResult.UserCantSignIn();
        }

        private string GenerateTokenFor(User user)
        {
            var key = System.Text.Encoding.ASCII.GetBytes(_jwtAuthorizationDetails.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Issuer = _jwtAuthorizationDetails.Issuer,
                Expires = DateTime.UtcNow.AddDays(_jwtAuthorizationDetails.ExpireDays),
                SigningCredentials = 
                    new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature
                        )
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
