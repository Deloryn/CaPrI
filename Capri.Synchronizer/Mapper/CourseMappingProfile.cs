using AutoMapper;
using PUT.WebServices.eDziekanatServiceClient;
using StudyScope = PUT.WebServices.eDziekanatServiceClient.eDziekanatService.StudyScope;

namespace Capri.Synchronizer.Mapper
{
    public class CourseMappingProfile : Profile
    {
        public CourseMappingProfile() {
            CreateMap<StudyScope, Capri.Database.Entities.Course>()
            .ForMember(
                capriCourse=> capriCourse.Id,
                o=>o.Ignore()
            )
            .ForMember(
                capriCourse=> capriCourse.Name,
                o=>o.MapFrom(studyScope => studyScope.GetName(Language.Polish))
            );
        }
    }
}