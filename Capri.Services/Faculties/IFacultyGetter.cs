using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Capri.Web.ViewModels.Faculty;

namespace Capri.Services.Faculties
{
    public interface IFacultyGetter
    {
        Task<IServiceResult<FacultyViewModel>> Get(int id);
        IServiceResult<IEnumerable<FacultyViewModel>> GetAll();
    }
}