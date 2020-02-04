using Microsoft.AspNetCore.Identity;
using AutoMapper;
using EKontoUser = PUT.WebServices.eKontoServiceClient.eKontoService.User;
using Capri.Database.Entities.Identity;

namespace Capri.Web.Configuration.Mapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<EKontoUser, User>()
                .ForMember(
                    user => user.Id,
                    o => o.MapFrom(eKontoUser => eKontoUser.id)
                )
                .ForMember(
                    user => user.Email,
                    o => o.MapFrom(eKontoUser => GetNormalizedEmailOf(eKontoUser))
                )
                .ForMember(
                    user => user.NormalizedEmail,
                    o => o.MapFrom(eKontoUser => GetNormalizedEmailOf(eKontoUser))
                )
                .ForMember(
                    user => user.EmailConfirmed,
                    o => o.MapFrom(eKontoUser => true)
                )
                .ForMember(
                    user => user.UserName,
                    o => o.MapFrom(eKontoUser => GetNormalizedEmailOf(eKontoUser))
                )
                .ForMember(
                    user => user.NormalizedUserName,
                    o => o.MapFrom(eKontoUser => GetNormalizedEmailOf(eKontoUser))
                );
        }

        private string GetNormalizedEmailOf(EKontoUser eKontoUser)
        {
            var email = GetEmailOf(eKontoUser);
            return new UpperInvariantLookupNormalizer()
                .Normalize(email)
                .ToUpperInvariant();
        }

        private string GetEmailOf(EKontoUser eKontoUser)
        {
            return eKontoUser.loginName + "@" + eKontoUser.loginDomain;
        }
    }
}
