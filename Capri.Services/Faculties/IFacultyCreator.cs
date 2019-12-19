using System.Threading.Tasks;
using Capri.Web.ViewModels.Faculty;

namespace Capri.Services.Faculties
{
    public interface IFacultyCreator
    {
         Task<IServiceResult<FacultyView>> Create(FacultyRegistration facultyRegistration);
    }
}