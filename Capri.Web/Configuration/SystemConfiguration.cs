using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Capri.Web.Services.Settings;

namespace Capri.Web.Configuration
{
    public static class SystemConfiguration
    {
        public static void AddSystemConfiguration(this IServiceCollection services, IConfiguration Configuration)
        {
            var systemSettingsSection = Configuration.GetSection("SystemSettings");
            services.Configure<SystemSettings>(systemSettingsSection);
        }
    }
}
