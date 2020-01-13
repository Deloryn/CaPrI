using System;
using System.Threading.Tasks;
using Capri.Web.ViewModels.Student;

namespace Capri.Services.Students
{
    public interface IStudentUpdater
    {
        Task<IServiceResult<StudentViewModel>> Update(Guid id, StudentRegistration newData);
    }
}