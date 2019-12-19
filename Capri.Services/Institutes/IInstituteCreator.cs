using System.Threading.Tasks;
using Capri.Web.ViewModels.Institute;

namespace Capri.Services.Institutes
{
    public interface IInstituteCreator
    {
         Task<IServiceResult<InstituteView>> Create(InstituteRegistration instituteRegistration);
    }
}