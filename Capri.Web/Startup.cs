using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.DependencyInjection;
using Capri.Web.Configuration;
using Capri.Services;

namespace Capri.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDatabaseConfiguration(Configuration["DbConnectionString"]);
            services.AddJwtConfiguration(Configuration.GetSection("JwtAuthorizationDetails"));
            services.AddSystemConfiguration(Configuration.GetSection("SystemSettings"));
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IProposalCreator, ProposalCreator>();
            services.AddScoped<IProposalDeleter, ProposalDeleter>();
            services.AddScoped<IProposalGetter, ProposalGetter>();
            services.AddScoped<IProposalUpdater, ProposalUpdater>();
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
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Users", action = "Login" });

                /*routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });*/
            });
        }
    }
}
