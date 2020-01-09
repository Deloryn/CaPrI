using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Capri.Web.ViewModels.Student;

namespace Capri.Services.Students
{
    public interface IStudentGetter
    {
        Task<IServiceResult<StudentViewModel>> Get(Guid id);
        IServiceResult<IEnumerable<StudentViewModel>> GetAll();
    }
}