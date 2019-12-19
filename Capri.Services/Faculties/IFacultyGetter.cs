using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Capri.Web.ViewModels.Faculty;

namespace Capri.Services.Faculties
{
    public interface IFacultyGetter
    {
        Task<IServiceResult<FacultyView>> Get(Guid id);
        IServiceResult<IEnumerable<FacultyView>> GetAll();
    }
}