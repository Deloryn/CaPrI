using System.Threading.Tasks;
using Capri.Database.Entities.Identity;

namespace Capri.Services.Users
{
    public interface IUserCreator
    {
        Task<IServiceResult<User>> CreateUser(
            string email, 
            string password, 
            RoleType[] roles);
    }
}
