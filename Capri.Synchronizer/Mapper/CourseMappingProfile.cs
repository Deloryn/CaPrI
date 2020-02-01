using AutoMapper;
using PUT.WebServices.eDziekanatServiceClient;
using StudyScopeElement = PUT.WebServices.eDziekanatServiceClient.eDziekanatService.StudyScopeElement;

namespace Capri.Synchronizer.Mapper
{
    public class CourseMappingProfile : Profile
    {
        public CourseMappingProfile() {
            CreateMap<StudyScopeElement, Capri.Database.Entities.Course>()
            .ForMember(
                capriCourse=> capriCourse.Id,
                o=>o.MapFrom(studyScopeElement => studyScopeElement.studyScope.symbol)
            )
            .ForMember(
                capriCourse=> capriCourse.Name,
                o=>o.MapFrom(studyScopeElement => studyScopeElement.studyScope.GetName(Language.Polish))
            );
        }
    }
}