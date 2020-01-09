using System.Threading.Tasks;
using Capri.Web.ViewModels.Student;

namespace Capri.Services.Students
{
    public interface IStudentCreator
    {
        Task<IServiceResult<StudentViewModel>> Create(StudentRegistration studentRegistration);
    }
}