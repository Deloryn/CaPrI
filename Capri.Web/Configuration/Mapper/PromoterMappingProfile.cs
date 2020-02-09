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
            CreateMap<PromoterUpdate, Promoter>();

            CreateMap<Promoter, PromoterViewModel>()
                .ForMember(
                    view => view.Proposals, 
                    o => o.MapFrom(promoter => promoter.Proposals.Select(p => p.Id))
                )
                .ForMember(
                    view => view.Email,
                    o => o.MapFrom(promoter => promoter.ApplicationUser.Email)
                );

            CreateMap<Promoter, PromoterJsonRecord>();

            CreateMap<PromoterJsonRecord, PromoterUpdate>();
        }
    }
}
