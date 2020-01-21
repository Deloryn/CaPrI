using System;
using Microsoft.AspNetCore.Identity;

namespace Capri.Database.Entities.Identity
{
    public class User : IdentityUser<Guid>, IEntity
    {
    }
}
