using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using PUT.WebServices.eKontoServiceClient;
using PUT.WebServices.eKadryServiceClient;
using PUT.WebServices.eDziekanatServiceClient;
using Capri.Services.Settings;

namespace Capri.Web.Configuration
{
    public static class PUTConfiguration
    {
        public static void AddPUTConfiguration(this IServiceCollection services, IConfigurationSection putSection)
        {
            services.Configure<PUTSettings>(putSection);

            var systemName = putSection.Get<PUTSettings>().SystemName;
            var systemPassword = putSection.Get<PUTSettings>().SystemPassword;

            services.AddScoped<IEKontoClient, eKontoClient>(p => new eKontoClient(systemName, systemPassword));

            services.AddScoped<IEKadryClient, eKadryClient>(p => {
                var eKontoClient = p.GetRequiredService(typeof(IEKontoClient)) as IEKontoClient;
                return new eKadryClient(eKontoClient);
            });
            
            services.AddScoped<IEDziekanatClient, eDziekanatClient>(p => {
                var eKontoClient = p.GetRequiredService(typeof(IEKontoClient)) as IEKontoClient;
                return new eDziekanatClient(eKontoClient);
            });
        }
    }
}
