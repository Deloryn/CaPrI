using Microsoft.Extensions.DependencyInjection;
using Capri.Database;
using Capri.Database.Entities.Identity;

namespace Capri.Web.Configuration
{
    public static class IdentityConfiguration
    {
        public static void AddIdentityConfiguration(this IServiceCollection services)
        {
            services.AddIdentity<User, IntRole>(options => {})
                    .AddEntityFrameworkStores<CapriDbContext>();
        }
    }
}
