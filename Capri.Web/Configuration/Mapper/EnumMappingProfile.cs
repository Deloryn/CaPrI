using System;
using System.ComponentModel;
using AutoMapper;
using Capri.Database.Entities;

namespace Capri.Web.Configuration.Mapper
{
    public class EnumMappingProfile : Profile
    {
        public EnumMappingProfile()
        {
            CreateMap<ProposalStatus, string>()
            .ConvertUsing(status => GetDescriptionOf(status));

            CreateMap<StudyLevel, string>()
            .ConvertUsing(level => GetDescriptionOf(level));

            CreateMap<StudyMode, string>()
            .ConvertUsing(mode => GetDescriptionOf(mode));

            CreateMap<StudyProfile, string>()
            .ConvertUsing(profile => GetDescriptionOf(profile));
        }

        private string GetDescriptionOf(Enum e)
        {
            var type = e.GetType();
            var memberInfos = type.GetMember(e.ToString());
            var memberInfo = memberInfos[0];
            var descriptionAttributes = memberInfo.GetCustomAttributes(typeof(DescriptionAttribute), true) as DescriptionAttribute[];

            if(descriptionAttributes.Length == 0)
            {
                return e.ToString();
            }
            return descriptionAttributes[0].Description;
        }
    }
}