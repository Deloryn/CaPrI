using System.Linq;
using AutoMapper;
using Capri.Database.Entities;
using Capri.Web.ViewModels.Faculty;

namespace Capri.Web.Configuration.Mapper
{
    public class FacultyMappingProfile : Profile
    {
        public FacultyMappingProfile()
        {
            CreateMap<FacultyRegistration, Faculty>();

            CreateMap<Faculty, FacultyView>()
            .ForMember(
                view=>view.Courses, 
                o=>o.MapFrom(faculty=>faculty.Courses.Select(c=>c.Id)));
        }
    }
}
