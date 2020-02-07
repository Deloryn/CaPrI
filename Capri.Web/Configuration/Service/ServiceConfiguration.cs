using Microsoft.Extensions.DependencyInjection;
using Capri.Services.Account;
using Capri.Services.Token;
using Capri.Services.Users;
using Capri.Services.Students;
using Capri.Services.Proposals;
using Capri.Services.Promoters;
using Capri.Services.Courses;
using Capri.Services.Faculties;
using Capri.Services.Institutes;
using Capri.Services.Settings;
using Capri.Services.Files;
using Capri.Services.DiplomaCard;

namespace Capri.Web.Configuration.Service
{
    public static class ServiceConfiguration
    {
        public static void AddServicesConfiguration(this IServiceCollection services)
        {
            services.AddPromoterServicesConfiguration();
            services.AddStudentServicesConfiguration();
            services.AddProposalServicesConfiguration();
            services.AddTokenServicesConfiguration();
            services.AddAccountServicesConfiguration();
            services.AddUserServicesConfiguration();
            services.AddCourseServicesConfiguration();
            services.AddFacultyServicesConfiguration();
            services.AddInstituteServicesConfiguration();
            services.AddSettingsServicesConfiguration();
            services.AddFileServicesConfiguration();
            services.AddDiplomaCardServicesConfiguration();
        }

        private static void AddPromoterServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IPromoterUpdater, PromoterUpdater>();
            services.AddScoped<IPromoterGetter, PromoterGetter>();
        }

        private static void AddStudentServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IStudentGetter, StudentGetter>();
        }

        private static void AddProposalServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IProposalCreator, ProposalCreator>();
            services.AddScoped<IProposalDeleter, ProposalDeleter>();
            services.AddScoped<IProposalGetter, ProposalGetter>();
            services.AddScoped<IProposalUpdater, ProposalUpdater>();
            services.AddScoped<ISubmittedProposalGetter, SubmittedProposalGetter>();
        }

        private static void AddTokenServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ITokenGenerator, TokenGenerator>();
        }

        private static void AddAccountServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ILogoutService, LogoutService>();
        }

        private static void AddUserServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IUserGetter, UserGetter>();
        }

        private static void AddCourseServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICourseGetter, CourseGetter>();
        }

        private static void AddInstituteServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IInstituteGetter, InstituteGetter>();
        }

        private static void AddFacultyServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IFacultyGetter, FacultyGetter>();
        }

        private static void AddSettingsServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ISystemSettingsGetter, SystemSettingsGetter>();
        }

        private static void AddFileServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICsvCreator, CsvCreator>();
            services.AddScoped<IDiplomaCardCreator, DiplomaCardCreator>();
        }

        private static void AddDiplomaCardServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IParagraphGetter, ParagraphGetter>();
            services.AddScoped<IDrawingGetter, DrawingGetter>();
            services.AddScoped<ITablePropertiesGetter, TablePropertiesGetter>();
            services.AddScoped<ITableGetter, TableGetter>();
        }
    }
}