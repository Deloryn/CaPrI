using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Capri.Database.Entities.Identity;
using Capri.Web.ViewModels.User;

namespace Capri.Services
{
    public interface IUserUpdater
    {
        Task<IServiceResult<User>> Update(
            Guid id, 
            UserCredentials credentials);
    }
}
