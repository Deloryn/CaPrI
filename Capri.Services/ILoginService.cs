using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capri.Web.ViewModels.User;

namespace Capri.Services
{
    public interface ILoginService
    {
        Task<ServiceResult<UserSecurityStamp>> Login(string username, string password);
    }
}
