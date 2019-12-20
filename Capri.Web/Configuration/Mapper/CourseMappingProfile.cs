using System.Linq;
using AutoMapper;
using Capri.Database.Entities;
using Capri.Web.ViewModels.Course;

namespace Capri.Web.Configuration.Mapper
{
    public class CourseMappingProfile : Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<CourseRegistration, Course>();

            CreateMap<Course, CourseView>()
            .ForMember(
                view=>view.Proposals, 
                o=>o.MapFrom(course=>course.Proposals.Select(p=>p.Id)));
        }
    }
}
