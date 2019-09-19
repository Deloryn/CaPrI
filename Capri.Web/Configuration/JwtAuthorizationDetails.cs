using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Capri.Web.Services.Settings;

namespace Capri.Web.Configuration
{
    public static class JwtConfiguration
    {
        private static IConfiguration Configuration { get; }

        public static void AddJwtConfiguration(this IServiceCollection services)
        {
            var jwtSection = Configuration.GetSection("JwtAuthorizationDetails");
            services.Configure<JwtAuthorizationDetails>(jwtSection);

            var secret = jwtSection.Get<JwtAuthorizationDetails>().Secret;
            var key = System.Text.Encoding.ASCII.GetBytes(secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}
