using System;
using System.Threading.Tasks;
using Capri.Web.ViewModels.Institute;

namespace Capri.Services.Institutes
{
    public interface IInstituteUpdater
    {
        Task<IServiceResult<InstituteView>> Update(Guid id, InstituteRegistration newData);
    }
}