using System;
using System.Threading.Tasks;
using Capri.Web.ViewModels.Student;

namespace Capri.Services.Students
{
    public interface IStudentDeleter
    {
        Task<IServiceResult<StudentViewModel>> Delete(Guid id);
        Task<IServiceResult<StudentViewModel>> Delete(int indexNumber);
    }
}