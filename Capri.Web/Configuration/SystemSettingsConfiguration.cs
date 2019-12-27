using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Capri.Services.Settings;

namespace Capri.Web.Configuration
{
    public static class SystemSettingsConfiguration
    {
        public static void AddSystemSettingsConfiguration(this IServiceCollection services, IConfigurationSection systemSection)
        {
            services.Configure<SystemSettings>(systemSection);
        }
    }
}
