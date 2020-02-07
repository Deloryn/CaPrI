using System.Threading.Tasks;
using Capri.Web.ViewModels.User;

namespace Capri.Services.Account
{
    public interface ILoginService
    {
        Task<IServiceResult<UserSecurityStamp>> Login(string sessionAuthorizationKey);
    }
}
