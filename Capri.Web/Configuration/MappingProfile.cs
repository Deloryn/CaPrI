using AutoMapper;
using Capri.Database.Entities;
using Capri.Web.ViewModels.Promoter;
using Capri.Web.ViewModels.Proposal;

namespace Capri.Web.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PromoterRegistration, Promoter>();
            CreateMap<ProposalRegistration, Proposal>();
            CreateMap<Proposal, ProposalViewModel>();
        }
    }
}
