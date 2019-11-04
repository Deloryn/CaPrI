using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Capri.Services;

namespace Capri.Web.Configuration
{
    public static class MapperConfiguration
    {
        public static void AddMapperConfiguration(
            this IServiceCollection services)
        {
            var mappingConfig = new AutoMapper.MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            AutoMapper.IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
