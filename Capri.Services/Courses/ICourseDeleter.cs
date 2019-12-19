using System;
using System.Threading.Tasks;
using Capri.Web.ViewModels.Course;

namespace Capri.Services.Courses
{
    public interface ICourseDeleter
    {
        Task<IServiceResult<CourseView>> Delete(Guid id);
    }
}