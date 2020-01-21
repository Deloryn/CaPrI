using System.Linq;
using AutoMapper;
using Capri.Database.Entities;
using Capri.Web.ViewModels.Promoter;

namespace Capri.Web.Configuration.Mapper
{
    public class PromoterMappingProfile : Profile
    {
        public PromoterMappingProfile()
        {
            CreateMap<PromoterRegistration, Promoter>();

            CreateMap<Promoter, PromoterViewModel>()
            .ForMember(
                view => view.Proposals,
                o => o.MapFrom(promoter => promoter.Proposals.Select(p => p.Id)));

            CreateMap<Promoter, PromoterJsonRecord>()
                .ForMember(view => view.Email, o => o.MapFrom(p => p.ApplicationUser.Email))
                .ForMember(view => view.Password, o => o.MapFrom(p => p.ApplicationUser.PasswordHash))
                .ForMember(view => view.Proposals, o => o.MapFrom(p => p.Proposals.Select(pr => pr.Id)));

        }
    }
}
