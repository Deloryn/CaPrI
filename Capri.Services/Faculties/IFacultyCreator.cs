using System.Threading.Tasks;
using Capri.Web.ViewModels.Faculty;

namespace Capri.Services.Faculties
{
    public interface IFacultyCreator
    {
         Task<IServiceResult<FacultyViewModel>> Create(FacultyRegistration facultyRegistration);
    }
}