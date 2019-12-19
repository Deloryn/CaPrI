using System.Linq;
using AutoMapper;
using Capri.Database.Entities;
using Capri.Web.ViewModels.Promoter;
using Capri.Web.ViewModels.Proposal;
using Capri.Web.ViewModels.Faculty;
using Capri.Web.ViewModels.Institute;
using Capri.Web.ViewModels.Course;

namespace Capri.Web.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PromoterRegistration, Promoter>();
            CreateMap<ProposalRegistration, Proposal>();
            CreateMap<FacultyRegistration, Faculty>();
            CreateMap<InstituteRegistration, Institute>();
            CreateMap<CourseRegistration, Course>();

            CreateMap<Promoter, PromoterView>()
            .ForMember(
                view=>view.Proposals, 
                o=>o.MapFrom(promoter=>promoter.Proposals.Select(p=>p.Id)));

            CreateMap<Proposal, ProposalView>()
            .ForMember(
                view=>view.Students, 
                o=>o.MapFrom(proposal=>proposal.Students.Select(s=>s.Id)));

            CreateMap<Faculty, FacultyView>()
            .ForMember(
                view=>view.Courses, 
                o=>o.MapFrom(faculty=>faculty.Courses.Select(c=>c.Id)));
            
            CreateMap<Institute, InstituteView>()
            .ForMember(
                view=>view.Promoters, 
                o=>o.MapFrom(institute=>institute.Promoters.Select(p=>p.Id)));

            CreateMap<Course, CourseView>()
            .ForMember(
                view=>view.Proposals, 
                o=>o.MapFrom(course=>course.Proposals.Select(p=>p.Id)));
        }
    }
}
