using System.Threading.Tasks;
using Capri.Web.ViewModels.Course;

namespace Capri.Services.Courses
{
    public interface ICourseCreator
    {
         Task<IServiceResult<CourseView>> Create(CourseRegistration courseRegistration);
    }
}