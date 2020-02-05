using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Autofac;
using AutoMapper;
using PUT.WebServices.eDziekanatServiceClient;
using PUT.WebServices.eKontoServiceClient;
using PUT.WebServices.eKadryServiceClient;
using Capri.Database;
using Capri.Synchronizer.Mapper;
using Capri.Synchronizer.Synchronizers;

namespace Capri.Synchronizer
{
    class Program
    {
        static void Main(string[] args)
        {
            CompositionRoot().Resolve<Application>().Run();
        }

        private static IContainer CompositionRoot()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory());

            var confBuilder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = confBuilder.Build();

            var connectionString = configuration["DbConnectionString"];
            var optionsBuilder = 
                new DbContextOptionsBuilder<CapriDbContext>()
                    .UseSqlServer(connectionString);
            var context = new CapriDbContext(optionsBuilder.Options);

            string systemName = configuration["SystemName"];
            string systemPassword = configuration["SystemPassword"];
            var eKontoClient = new eKontoClient(systemName, systemPassword);
            var eDziekanatClient = new eDziekanatClient(eKontoClient);
            var eKadryClient = new eKadryClient(eKontoClient);

            var mappingConfig = new AutoMapper.MapperConfiguration(mc =>
            {
                mc.AddProfile(new FacultyMappingProfile());
                mc.AddProfile(new CourseMappingProfile());
                mc.AddProfile(new InstituteMappingProfile());
                mc.AddProfile(new PromoterMappingProfile());
            });
            var mapper = mappingConfig.CreateMapper();

            var builder = new ContainerBuilder();
            builder.RegisterInstance(context).As<ISqlDbContext>();
            builder.RegisterInstance(mapper).As<IMapper>();
            builder.RegisterInstance(eKontoClient).As<IEKontoClient>();
            builder.RegisterInstance(eDziekanatClient).As<IEDziekanatClient>();
            builder.RegisterInstance(eKadryClient).As<IEKadryClient>();
            builder.RegisterType<RoleSynchronizer>().As<IRoleSynchronizer>();
            builder.RegisterType<FacultySynchronizer>().As<IFacultySynchronizer>();
            builder.RegisterType<CourseSynchronizer>().As<ICourseSynchronizer>();
            builder.RegisterType<InstituteSynchronizer>().As<IInstituteSynchronizer>();
            builder.RegisterType<PromoterSynchronizer>().As<IPromoterSynchronizer>();
            builder.RegisterType<Application>();

            return builder.Build();
        }
    }
}
