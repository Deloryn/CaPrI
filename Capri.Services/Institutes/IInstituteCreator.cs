using System.Threading.Tasks;
using Capri.Web.ViewModels.Institute;

namespace Capri.Services.Institutes
{
    public interface IInstituteCreator
    {
         Task<IServiceResult<InstituteViewModel>> Create(InstituteRegistration instituteRegistration);
    }
}