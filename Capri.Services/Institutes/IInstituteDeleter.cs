using System;
using System.Threading.Tasks;
using Capri.Web.ViewModels.Institute;

namespace Capri.Services.Institutes
{
    public interface IInstituteDeleter
    {
        Task<IServiceResult<InstituteView>> Delete(Guid id);
    }
}