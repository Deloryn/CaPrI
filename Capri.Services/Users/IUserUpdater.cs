using System;
using System.Threading.Tasks;
using Capri.Database.Entities.Identity;
using Capri.Web.ViewModels.User;

namespace Capri.Services.Users
{
    public interface IUserUpdater
    {
        Task<IServiceResult<User>> Update(Guid id, UserCredentials credentials, bool passwordHashed = false);
    }
}
