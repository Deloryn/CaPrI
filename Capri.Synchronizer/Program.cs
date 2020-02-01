﻿using System;
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
            string systemName = "";
            Console.Write(string.Format("Podaj hasło systemu {0} w eKoncie: ", systemName));
            string systemPassword = Console.ReadLine();

            var eKontoClient = new eKontoClient(systemName, systemPassword);
            var eDziekanatClient = new eDziekanatClient(eKontoClient);
            var eKadryClient = new eKadryClient(eKontoClient);

            var connectionString = "";
            var optionsBuilder = 
                new DbContextOptionsBuilder<CapriDbContext>()
                    .UseSqlServer(connectionString);
            var context = new CapriDbContext(optionsBuilder.Options);

            var mappingConfig = new AutoMapper.MapperConfiguration(mc =>
            {
                mc.AddProfile(new FacultyMappingProfile());
                mc.AddProfile(new CourseMappingProfile());
            });

            var mapper = mappingConfig.CreateMapper();

            var builder = new ContainerBuilder();

            builder.RegisterInstance(context).As<ISqlDbContext>();
            builder.RegisterInstance(mapper).As<IMapper>();
            builder.RegisterInstance(eKontoClient).As<IEKontoClient>();
            builder.RegisterInstance(eDziekanatClient).As<IEDziekanatClient>();
            builder.RegisterInstance(eKadryClient).As<IEKadryClient>();

            builder.RegisterType<FacultySynchronizer>().As<IFacultySynchronizer>();
            builder.RegisterType<CourseSynchronizer>().As<ICourseSynchronizer>();
            builder.RegisterType<InstituteSynchronizer>().As<IInstituteSynchronizer>();
            builder.RegisterType<Application>();

            return builder.Build();
        }
    }
}
