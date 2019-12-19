using System;
using System.Threading.Tasks;
using Capri.Web.ViewModels.Course;

namespace Capri.Services.Courses
{
    public interface ICourseUpdater
    {
        Task<IServiceResult<CourseView>> Update(Guid id, CourseRegistration newData);
    }
}