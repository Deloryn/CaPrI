using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capri.Database.Entities.Identity
{
    public class GuidRole : IdentityRole<Guid>
    {
        public GuidRole()
        {
            Id = Guid.NewGuid();
        }
        public GuidRole(string name) : this() { Name = name; }
    }
}
