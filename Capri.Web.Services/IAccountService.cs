using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capri.Web.DTO;

namespace Capri.Web.Services
{
    public interface IAccountService
    {
        UserTokenDTO Authenticate(string username, string password);
    }
}
