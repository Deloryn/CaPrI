using System.Threading.Tasks;
using Capri.Database.Entities.Identity;

namespace Capri.Services.Users
{
    public interface IUserGetter
    {
        Task<IServiceResult<User>> GetCurrentUser();
    }
}
