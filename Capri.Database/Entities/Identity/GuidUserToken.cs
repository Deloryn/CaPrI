using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Capri.Database.Entities.Identity
{
    public class GuidUserToken : IdentityUserToken<Guid>
    {
        [Key]
        public Guid Id { get; set; }
    }
}
