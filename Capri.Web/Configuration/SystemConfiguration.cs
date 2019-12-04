using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Capri.Services.Settings;

namespace Capri.Web.Configuration
{
    public static class SystemConfiguration
    {
        public static void AddSystemConfiguration(
            this IServiceCollection services, 
            IConfigurationSection systemSection)
        {
            services.Configure<SystemSettings>(systemSection);
        }
    }
}
