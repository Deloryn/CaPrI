using AutoMapper;
using Department = PUT.WebServices.eKadryServiceClient.eKadryService.Department;

namespace Capri.Synchronizer.Mapper
{
    public class InstituteMappingProfile : Profile
    {
        public InstituteMappingProfile() {
            CreateMap<Department, Capri.Database.Entities.Course>()
            .ForMember(
                capriInstitute=> capriInstitute.Id,
                o=>o.MapFrom(department => department.id)
            )
            .ForMember(
                capriInstitute=> capriInstitute.Name,
                o=>o.MapFrom(department => department.name)
            );
        }   
    }
}