using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Capri.Database;

namespace Capri.Web.Configuration
{
    public static class DatabaseConfiguration
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CapriDbContext>(
                options => options.UseSqlServer(connectionString));

            services.AddScoped<ISqlDbContext, CapriDbContext>();
        }
    }
}
