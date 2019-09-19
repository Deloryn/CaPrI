using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capri.Web.Services
{
    public interface ILoginService
    {
        Task<IServiceResult> Login(string username, string password);
    }
}
