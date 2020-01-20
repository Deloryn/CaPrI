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

            CreateMap<Proposal, ProposalCsvRecord>()
            .ForMember(csv => csv.Promoter, o => o.MapFrom(p => GetPromoterFullName(p.Promoter)))
            .ForMember(csv => csv.Course, o => o.MapFrom(p => p.Course.Name))
            .ForMember(csv => csv.Faculty, o => o.MapFrom(p => p.Course.Faculty.Name))
            .ForMember(csv => csv.Institute, o => o.MapFrom(p => p.Promoter.Institute.Name));

            CreateMap<Proposal, ProposalDocRecord>()
                .ForMember(csv => csv.Promoter, o => o.MapFrom(p => GetPromoterFullName(p.Promoter)))
                .ForMember(csv => csv.Course, o => o.MapFrom(p => p.Course.Name))
                .ForMember(csv => csv.Faculty, o => o.MapFrom(p => p.Course.Faculty.Name))
                .ForMember(csv => csv.Institute, o => o.MapFrom(p => p.Promoter.Institute.Name));
        }

        private string GetPromoterFullName(Promoter promoter)
        {
            var fullName = $"{promoter.TitlePrefix} {promoter.FirstName} {promoter.LastName}";
            if(promoter.TitlePostfix == null)
            {
                return fullName;
            }
            else if(promoter.TitlePostfix == string.Empty)
            {
                return fullName;
            }
            return $"{fullName}, {promoter.TitlePostfix}";
        }
    }
}
