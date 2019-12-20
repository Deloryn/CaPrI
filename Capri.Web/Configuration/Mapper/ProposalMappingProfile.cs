using System.Linq;
using AutoMapper;
using Capri.Database.Entities;
using Capri.Web.ViewModels.Proposal;

namespace Capri.Web.Configuration.Mapper
{
    public class ProposalMappingProfile : Profile
    {
        public ProposalMappingProfile()
        {
            CreateMap<ProposalRegistration, Proposal>();

            CreateMap<Proposal, ProposalView>()
            .ForMember(
                view=>view.Students, 
                o=>o.MapFrom(proposal=>proposal.Students.Select(s=>s.Id)));
        }
    }
}
