using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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
