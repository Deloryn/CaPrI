using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capri.Web.ViewModels.User;

namespace Capri.Web.Services
{
    public interface IAccountService
    {
        UserSecurityStamp Authenticate(string username, string password);
    }
}
