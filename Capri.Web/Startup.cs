using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Capri.Web.Configuration;
using Capri.Web.Configuration.Sieve;
using Capri.Web.Configuration.Mapper;
using Capri.Web.Configuration.Service;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace Capri.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("pl")
                };
                options.DefaultRequestCulture = new RequestCulture(culture: "pl", uiCulture: "pl");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            services.AddMvc();
            services.AddDatabaseConfiguration(Configuration["DbConnectionString"]);
            services.AddIdentityConfiguration();
            services.AddSystemSettingsConfiguration(Configuration.GetSection("SystemSettings"));
            services.AddJwtConfiguration(Configuration.GetSection("JwtAuthorizationDetails"));
            services.AddSieveConfiguration(Configuration.GetSection("SieveSettings"));
            services.AddMapperConfiguration();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddServicesConfiguration();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions()
                {
                    HotModuleReplacement = true
                });
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRequestLocalization();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
