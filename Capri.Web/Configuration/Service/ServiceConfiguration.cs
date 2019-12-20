using Microsoft.Extensions.DependencyInjection;
using Capri.Services.Account;
using Capri.Services.Token;
using Capri.Services.Users;
using Capri.Services.Proposals;
using Capri.Services.Promoters;
using Capri.Services.Courses;
using Capri.Services.Faculties;
using Capri.Services.Institutes;

namespace Capri.Web.Configuration.Service
{
    public static class ServiceConfiguration
    {
        public static void AddServiceConfiguration(this IServiceCollection services)
        {
            services.AddPromoterServiceConfiguration();
            services.AddProposalServiceConfiguration();
            services.AddTokenServiceConfiguration();
            services.AddAccountServiceConfiguration();
            services.AddUserServiceConfiguration();
            services.AddCourseServiceConfiguration();
            services.AddFacultyServiceConfiguration();
            services.AddInstituteServiceConfiguration();
        }

        private static void AddPromoterServiceConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IPromoterCreator, PromoterCreator>();
            services.AddScoped<IPromoterUpdater, PromoterUpdater>();
            services.AddScoped<IPromoterGetter, PromoterGetter>();
            services.AddScoped<IPromoterDeleter, PromoterDeleter>();
        }

        private static void AddProposalServiceConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IProposalCreator, ProposalCreator>();
            services.AddScoped<IProposalDeleter, ProposalDeleter>();
            services.AddScoped<IProposalGetter, ProposalGetter>();
            services.AddScoped<IProposalUpdater, ProposalUpdater>();
            services.AddScoped<ISubmittedProposalGetter, SubmittedProposalGetter>();
        }

        private static void AddTokenServiceConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ITokenGenerator, TokenGenerator>();
        }

        private static void AddAccountServiceConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
        }

        private static void AddUserServiceConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IUserCreator, UserCreator>();
            services.AddScoped<IUserUpdater, UserUpdater>();
            services.AddScoped<IUserGetter, UserGetter>();
        }

        private static void AddCourseServiceConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICourseCreator, CourseCreator>();
            services.AddScoped<ICourseUpdater, CourseUpdater>();
            services.AddScoped<ICourseGetter, CourseGetter>();
            services.AddScoped<ICourseDeleter, CourseDeleter>();
        }

        private static void AddInstituteServiceConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IInstituteCreator, InstituteCreator>();
            services.AddScoped<IInstituteUpdater, InstituteUpdater>();
            services.AddScoped<IInstituteGetter, InstituteGetter>();
            services.AddScoped<IInstituteDeleter, InstituteDeleter>();
        }

        private static void AddFacultyServiceConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IFacultyCreator, FacultyCreator>();
            services.AddScoped<IFacultyUpdater, FacultyUpdater>();
            services.AddScoped<IFacultyGetter, FacultyGetter>();
            services.AddScoped<IFacultyDeleter, FacultyDeleter>();
        }
    }
}