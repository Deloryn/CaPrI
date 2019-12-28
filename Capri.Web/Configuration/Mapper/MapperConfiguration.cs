﻿using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace Capri.Web.Configuration.Mapper
{
    public static class MapperConfiguration
    {
        public static void AddMapperConfiguration(
            this IServiceCollection services)
        {
            var mappingConfig = new AutoMapper.MapperConfiguration(mc =>
            {
                mc.AddProfile(new PromoterMappingProfile());
                mc.AddProfile(new ProposalMappingProfile());
                mc.AddProfile(new FacultyMappingProfile());
                mc.AddProfile(new CourseMappingProfile());
                mc.AddProfile(new InstituteMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}