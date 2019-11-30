using System;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Capri.Database.Entities.Identity;
using Capri.Services.Settings;

namespace Capri.Services.Token
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly JwtAuthorizationDetails _jwtAuthDetails;

        public TokenGenerator(
            IOptions<JwtAuthorizationDetails> jwtSettingsOptions)
        {
            _jwtAuthDetails = jwtSettingsOptions.Value;
        }

        public string GenerateTokenFor(User user)
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
