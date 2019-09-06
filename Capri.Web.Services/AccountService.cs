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
    public class AccountService : IAccountService
    {
        private readonly SignInManager<User> _signInManager;

        private readonly UserManager<User> _userManager;

        private readonly JWTSettings _jwtSettings;

        public AccountService(SignInManager<User> signInManager, UserManager<User> userManager, IOptions<JWTSettings> jwtSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<UserSecurityStamp> Authenticate(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var canSignIn = await _signInManager.CanSignInAsync(user);
            if(canSignIn)
            {
                await _userManager.UpdateSecurityStampAsync(user);
                var result = await _signInManager.PasswordSignInAsync(email, password, true, false);
                if(result.Succeeded)
                {
                    return new UserSecurityStamp
                    {
                        Email = user.Email,
                        SecurityStamp = user.SecurityStamp
                    };
                }
            }
            return null;
        }

        private string GenerateTokenFor(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
