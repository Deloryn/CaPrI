using System.Linq;
using AutoMapper;
using Capri.Database.Entities;
using Capri.Web.ViewModels.Student;

namespace Capri.Web.Configuration.Mapper
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<StudentRegistration, Student>();
            CreateMap<Student, StudentViewModel>();
        }
    }
}
