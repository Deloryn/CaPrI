using Microsoft.Extensions.DependencyInjection;
using Capri.Services.Account;
using Capri.Services.Token;
using Capri.Services.Users;
using Capri.Services.Proposals;
using Capri.Services.Promoters;
using Capri.Services.Courses;
using Capri.Services.Faculties;
using Capri.Services.Institutes;
using Capri.Services.Settings;
using Capri.Services.Files;

namespace Capri.Web.Configuration.Service
{
    public static class ServiceConfiguration
    {
        public static void AddServicesConfiguration(this IServiceCollection services)
        {
            services.AddPromoterServicesConfiguration();
            services.AddProposalServicesConfiguration();
            services.AddTokenServicesConfiguration();
            services.AddAccountServicesConfiguration();
            services.AddUserServicesConfiguration();
            services.AddCourseServicesConfiguration();
            services.AddFacultyServicesConfiguration();
            services.AddInstituteServicesConfiguration();
            services.AddSettingsServicesConfiguration();
            services.AddFileServicesConfiguration();
        }

        private static void AddPromoterServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IPromoterCreator, PromoterCreator>();
            services.AddScoped<IPromoterUpdater, PromoterUpdater>();
            services.AddScoped<IPromoterGetter, PromoterGetter>();
            services.AddScoped<IPromoterDeleter, PromoterDeleter>();
        }

        private static void AddProposalServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IProposalCreator, ProposalCreator>();
            services.AddScoped<IProposalDeleter, ProposalDeleter>();
            services.AddScoped<IProposalGetter, ProposalGetter>();
            services.AddScoped<IProposalUpdater, ProposalUpdater>();
            services.AddScoped<ISubmittedProposalGetter, SubmittedProposalGetter>();
            services.AddScoped<IProposalInformer, ProposalInformer>();
        }

        private static void AddTokenServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ITokenGenerator, TokenGenerator>();
        }

        private static void AddAccountServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
        }

        private static void AddUserServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IUserCreator, UserCreator>();
            services.AddScoped<IUserUpdater, UserUpdater>();
            services.AddScoped<IUserGetter, UserGetter>();
        }

        private static void AddCourseServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICourseCreator, CourseCreator>();
            services.AddScoped<ICourseUpdater, CourseUpdater>();
            services.AddScoped<ICourseGetter, CourseGetter>();
            services.AddScoped<ICourseDeleter, CourseDeleter>();
        }

        private static void AddInstituteServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IInstituteCreator, InstituteCreator>();
            services.AddScoped<IInstituteUpdater, InstituteUpdater>();
            services.AddScoped<IInstituteGetter, InstituteGetter>();
            services.AddScoped<IInstituteDeleter, InstituteDeleter>();
        }

        private static void AddFacultyServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IFacultyCreator, FacultyCreator>();
            services.AddScoped<IFacultyUpdater, FacultyUpdater>();
            services.AddScoped<IFacultyGetter, FacultyGetter>();
            services.AddScoped<IFacultyDeleter, FacultyDeleter>();
        }

        private static void AddSettingsServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ISystemSettingsGetter, SystemSettingsGetter>();
        }

        private static void AddFileServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICsvCreator, CsvCreator>();
        }
    }
}