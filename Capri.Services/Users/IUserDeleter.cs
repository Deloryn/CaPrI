using System;
using System.Threading.Tasks;
using Capri.Database.Entities.Identity;

namespace Capri.Services.Users
{
    public interface IUserDeleter
    {
        Task<IServiceResult<User>> Delete(int id);
    }
}