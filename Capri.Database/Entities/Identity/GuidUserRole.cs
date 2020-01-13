using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Capri.Database.Entities.Identity
{
    public class GuidUserRole : IdentityUserRole<Guid>
    {
        [Key]
        public Guid Id { get; set; }
    }
}
