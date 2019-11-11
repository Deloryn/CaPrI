using Capri.Database.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capri.Services
{
    public interface IApplicationUserGetter
    {
        Task<User> GetCurrentUser();
    }
}
