using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Capri.Database.Entities.Identity
{
    public class User : IdentityUser<Guid>, IEntity
    {
    }
}
