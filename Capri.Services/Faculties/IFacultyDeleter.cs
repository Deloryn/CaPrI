using System;
using System.Threading.Tasks;
using Capri.Web.ViewModels.Faculty;

namespace Capri.Services.Faculties
{
    public interface IFacultyDeleter
    {
        Task<IServiceResult<FacultyViewModel>> Delete(Guid id);
    }
}