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
                mc.AddProfile(new StudentMappingProfile());
                mc.AddProfile(new ProposalMappingProfile());
                mc.AddProfile(new FacultyMappingProfile());
                mc.AddProfile(new CourseMappingProfile());
                mc.AddProfile(new InstituteMappingProfile());
                mc.AddProfile(new EnumMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
