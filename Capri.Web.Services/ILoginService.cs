using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capri.Web.ViewModels.User;

namespace Capri.Web.Services
{
    public interface ILoginService
    {
        Task<UserSecurityStamp> Login(string username, string password);
    }
}
