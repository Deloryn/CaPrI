using System.Collections;
using System;
using System.Collections.Generic;
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

            CreateMap<ProposalRegistration, Proposal>()
            .ForMember(
                proposal => proposal.StudentIndexNumbers,
                o => o.MapFrom(registration => GetStudentIndexNumbersString(registration.Students)))
            .ForMember(
                proposal => proposal.Status,
                o => o.MapFrom(registration => CalculateProposalStatus(registration))
            );

            CreateMap<Proposal, ProposalViewModel>()
            .ForMember(
                view=>view.Students, 
                o=>o.MapFrom(proposal=> GetStudentIndexNumbersFromString(proposal.StudentIndexNumbers)));

            CreateMap<Proposal, ProposalCsvRecord>()
            .ForMember(csv => csv.Promoter, o => o.MapFrom(p => GetPromoterFullName(p.Promoter)))
            .ForMember(csv => csv.Course, o => o.MapFrom(p => p.Course.Name))
            .ForMember(csv => csv.Faculty, o => o.MapFrom(p => p.Course.Faculty.Name))
            .ForMember(csv => csv.Institute, o => o.MapFrom(p => p.Promoter.Institute.Name));
        }

        private ProposalStatus CalculateProposalStatus(ProposalRegistration registration)
        {
            var students = registration.Students;
            var maxNumberOfStudents = registration.MaxNumberOfStudents;

            if(students == null)
            {
                return ProposalStatus.Free;
            }
            else if(students.Count() < maxNumberOfStudents)
            {
                return ProposalStatus.PartiallyTaken;
            }
            else if(students.Count() == maxNumberOfStudents)
            {
                return ProposalStatus.Taken;
            }
            else
            {
                return ProposalStatus.Overloaded;
            }
        }

        private string GetStudentIndexNumbersString(ICollection<int> indexNumbers)
        {
            var stringNumbers = indexNumbers.Select(num => num.ToString());
            return String.Join(",", stringNumbers);
        }

        private ICollection<int> GetStudentIndexNumbersFromString(string indexNumbersString)
        {
            return indexNumbersString
                .Split(",")
                .Select(str => Int32.Parse(str))
                .ToList();
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
