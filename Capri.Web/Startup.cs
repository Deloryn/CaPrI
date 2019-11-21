using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.DependencyInjection;
using Capri.Web.Configuration;
using Capri.Services;
using Microsoft.AspNetCore.Http;
using Capri.Services.Proposals;

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
            services.AddMapperConfiguration();
            services.AddHttpContextAccessor();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IProposalCreator, ProposalCreator>();
            services.AddScoped<IProposalDeleter, ProposalDeleter>();
            services.AddScoped<IProposalGetter, ProposalGetter>();
            services.AddScoped<IProposalUpdater, ProposalUpdater>();
            services.AddScoped<ISubmittedProposalGetter, SubmittedProposalGetter>();
            services.AddScoped<IPromoterCreator, PromoterCreator>();
            services.AddScoped<IPromoterUpdater, PromoterUpdater>();
            services.AddScoped<IPromoterGetter, PromoterGetter>();
            services.AddScoped<IPromoterDeleter, PromoterDeleter>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IUserCreator, UserCreator>();
            services.AddScoped<IUserUpdater, UserUpdater>();
            services.AddScoped<IApplicationUserGetter, ApplicationUserGetter>();
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
                    defaults: new { controller = "Account", action = "Login" });
            });
        }
    }
}
