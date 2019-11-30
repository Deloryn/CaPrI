using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Sieve.Models;
using Sieve.Services;

namespace Capri.Web.Configuration.Sieve
{
    public static class SieveConfiguration
    {
        public static void AddSieveConfiguration(
            this IServiceCollection services,
            IConfigurationSection sieveSection)
        {
            services.Configure<SieveOptions>(sieveSection);
            services.AddScoped<ISieveProcessor, CapriSieveProcessor>();
        }
    }
}