using System;
using System.Threading.Tasks;
using Capri.Web.ViewModels.Institute;

namespace Capri.Services.Institutes
{
    public interface IInstituteUpdater
    {
        Task<IServiceResult<InstituteViewModel>> Update(Guid id, InstituteRegistration newData);
    }
}