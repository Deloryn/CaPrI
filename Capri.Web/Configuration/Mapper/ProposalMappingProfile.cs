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

            CreateMap<Proposal, ProposalViewModel>()
            .ForMember(
                view=>view.Students, 
                o=>o.MapFrom(proposal=>proposal.Students.Select(s=>s.Id)));

            CreateMap<Proposal, ProposalCsv>()
            .ForMember(csv => csv.Promoter, o => o.MapFrom(p =>
                $"{p.Promoter.TitlePrefix} {p.Promoter.FirstName} {p.Promoter.LastName}{", " + p.Promoter.TitlePostfix ?? ""}"))
            .ForMember(csv => csv.Course, o => o.MapFrom(p => p.Course.Name))
            .ForMember(csv => csv.Faculty, o => o.MapFrom(p => p.Course.Faculty.Name))
            .ForMember(csv => csv.Institute, o => o.MapFrom(p => p.Promoter.Institute.Name));
        }
    }
}
