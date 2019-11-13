using System;
using System.Collections.Generic;
using System.Text;
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
            CreateMap<PromoterUpdate, Promoter>();
            CreateMap<ProposalUpdate, Proposal>();
            CreateMap<ProposalRegistration, Proposal>();
        }
    }
}
