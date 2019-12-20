using System.Linq;
using AutoMapper;
using Capri.Database.Entities;
using Capri.Web.ViewModels.Institute;

namespace Capri.Web.Configuration.Mapper
{
    public class InstituteMappingProfile : Profile
    {
        public InstituteMappingProfile()
        {
            CreateMap<InstituteRegistration, Institute>();
            
            CreateMap<Institute, InstituteView>()
            .ForMember(
                view=>view.Promoters, 
                o=>o.MapFrom(institute=>institute.Promoters.Select(p=>p.Id)));
        }
    }
}
