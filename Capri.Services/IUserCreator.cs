using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Capri.Database.Entities.Identity;

namespace Capri.Services
{
    public interface IUserCreator
    {
        Task<IServiceResult<User>> CreateUser(string email, string password);
    }
}
