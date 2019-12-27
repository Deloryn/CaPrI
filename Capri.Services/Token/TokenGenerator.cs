using System;
using System.Collections.Generic;
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
            var claims = GenerateClaims(user);
            return CreateTokenFromClaims(claims);
        }

        public string GenerateTokenFor(User user, ICollection<string> roles)
        {
            var claims = GenerateClaims(user, roles);
            return CreateTokenFromClaims(claims);
        }

        private ICollection<Claim> GenerateClaims(User user, ICollection<string> roles)
        {
            var claims = new List<Claim>();
            foreach(var claim in GenerateClaims(user))
            {
                claims.Add(claim);
            }
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        private ICollection<Claim> GenerateClaims(User user)
        {
            return new Claim[] 
            {
                new Claim(ClaimTypes.Name, user.Id.ToString())
            };
        }

        private string CreateTokenFromClaims(ICollection<Claim> claims)
        {
            var key = System.Text.Encoding.ASCII.GetBytes(_jwtAuthDetails.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims, "jwt"),
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
