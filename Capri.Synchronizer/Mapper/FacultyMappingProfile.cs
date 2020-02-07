using AutoMapper;
using PUT.WebServices.eDziekanatServiceClient;
using EDziekanatFaculty = PUT.WebServices.eDziekanatServiceClient.eDziekanatService.Faculty;

namespace Capri.Synchronizer.Mapper
{
    public class FacultyMappingProfile : Profile
    {
        public FacultyMappingProfile()
        {
            CreateMap<EDziekanatFaculty, Capri.Database.Entities.Faculty>()
            .ForMember(
                capriFaculty => capriFaculty.Id,
                o=>o.MapFrom(eDziekanatFaculty => eDziekanatFaculty.id)
            )
            .ForMember(
                capriFaculty => capriFaculty.Name,
                o=>o.MapFrom(eDziekanatFaculty => eDziekanatFaculty.GetName(Language.Polish))
            );
        }
    }
}