using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Capri.Web.ViewModels.Course;

namespace Capri.Services.Courses
{
    public interface ICourseGetter
    {
        Task<IServiceResult<CourseViewModel>> Get(string id);
        IServiceResult<IEnumerable<CourseViewModel>> GetAll();
    }
}