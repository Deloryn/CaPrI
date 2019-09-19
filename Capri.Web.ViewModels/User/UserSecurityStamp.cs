using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capri.Web.ViewModels.User
{
    public class UserSecurityStamp : Result
    {
        public string Email { get; set; }
        public string SecurityStamp { get; set; }
    }
}
