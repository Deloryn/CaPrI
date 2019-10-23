using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Capri.Database.Entities.Identity
{
    public class GuidUserRole : IdentityUserRole<Guid>
    {
        [Key]
        public Guid Id { get; set; }
    }
}
