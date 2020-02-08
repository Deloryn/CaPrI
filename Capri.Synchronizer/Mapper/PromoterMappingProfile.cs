using AutoMapper;
using EKontoUser = PUT.WebServices.eKontoServiceClient.eKontoService.User;
using EKadryEmployee = PUT.WebServices.eKadryServiceClient.eKadryService.Employee;
using Capri.Database.Entities;

namespace Capri.Synchronizer.Mapper
{
    public class PromoterMappingProfile: Profile
    {
        public PromoterMappingProfile()
        {
            CreateMap<EKontoUser, Promoter>()
                .ForMember(dest => dest.FirstName, o => o.MapFrom(u => u.name))
                .ForMember(dest => dest.LastName, o => o.MapFrom(u => u.surname));
            CreateMap<EKadryEmployee, Promoter>()
                .ForMember(dest => dest.TitlePrefix, o => o.MapFrom(u => u.title));
        }
    }
}
