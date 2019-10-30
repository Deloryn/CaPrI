using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Capri.Database.Entities;
using Capri.Web.ViewModels.Promoter;

namespace Capri.Web.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PromoterUpdate, Promoter>();
        }
    }
}
