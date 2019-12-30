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
            .ConvertUsing(status => GetDescriptionOrElseNameOf(status));

            CreateMap<StudyLevel, string>()
            .ConvertUsing(level => GetDescriptionOrElseNameOf(level));

            CreateMap<StudyMode, string>()
            .ConvertUsing(mode => GetDescriptionOrElseNameOf(mode));

            CreateMap<StudyProfile, string>()
            .ConvertUsing(profile => GetDescriptionOrElseNameOf(profile));
        }

        private string GetDescriptionOrElseNameOf(Enum e)
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