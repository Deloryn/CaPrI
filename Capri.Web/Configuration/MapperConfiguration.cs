using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

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

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
