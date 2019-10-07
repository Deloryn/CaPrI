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
using Capri.Services.Settings;
using Capri.Web.ViewModels.User;

namespace Capri.Services
{
    public class LoginService : ILoginService
    {
        private readonly SignInManager<User> _signInManager;

        private readonly UserManager<User> _userManager;

        private readonly JwtAuthorizationDetails _jwtAuthDetails;

        public LoginService(
            SignInManager<User> signInManager, 
            UserManager<User> userManager, 
            IOptions<JwtAuthorizationDetails> jwtSettingsOptions)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtAuthDetails = jwtSettingsOptions.Value;
        }

        public async Task<ServiceResult<UserSecurityStamp>> Login(string email, string password)
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
                    string token = GenerateTokenFor(user);
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

        private string GenerateTokenFor(User user)
        {
            var key = System.Text.Encoding.ASCII.GetBytes(_jwtAuthDetails.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Issuer = _jwtAuthDetails.Issuer,
                Expires = DateTime.UtcNow.AddDays(_jwtAuthDetails.ExpireDays),
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
