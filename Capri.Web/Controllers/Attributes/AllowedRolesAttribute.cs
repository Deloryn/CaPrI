using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Capri.Database.Entities.Identity;

namespace Capri.Web.Controllers.Attributes
{
    public class AllowedRolesAttribute : AuthorizeAttribute
    {
        public AllowedRolesAttribute(params RoleType[] allowedRoles)
        {
            var allowedRolesAsStrings = allowedRoles.Select(x => Enum.GetName(typeof(RoleType), x));
            Roles = string.Join(",", allowedRolesAsStrings);
        }
    }
}