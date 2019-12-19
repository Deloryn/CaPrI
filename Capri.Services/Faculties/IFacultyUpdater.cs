using System;
using System.Threading.Tasks;
using Capri.Web.ViewModels.Faculty;

namespace Capri.Services.Faculties
{
    public interface IFacultyUpdater
    {
        Task<IServiceResult<FacultyView>> Update(Guid id, FacultyRegistration newData);
    }
}