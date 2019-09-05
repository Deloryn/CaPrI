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
        private readonly ISqlDbContext _context;

        private readonly JWTSettings _jwtSettings;

        public AccountService(ISqlDbContext context, IOptions<JWTSettings> jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings.Value;
        }

        public UserToken Authenticate(string email, string password)
        {
            User user = FindUserByEmail(email);
            if (user == null)
            {
                return null;
            }
            else if (!IsPasswordCorrect(user, password))
            {
                return null;
            }
            else
            {
                user.Token = GenerateTokenFor(user);
                _context.Users.Update(user);
                _context.SaveChangesAsync();
                UserToken userToken = new UserToken
                {
                    Email = user.Email,
                    Token = user.Token
                };
                return userToken;
            }
        }

        private User FindUserByEmail(string email)
        {
            return this._context.Users.FirstOrDefault(s => s.Email == email);
        }

        private bool IsPasswordCorrect(User user, string password)
        {
            PasswordVerificationResult result = new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, password);
            return result != PasswordVerificationResult.Failed;
        }

        private string GenerateTokenFor(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.ID.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
