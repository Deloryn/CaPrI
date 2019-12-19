using System;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using Capri.Database;
using Capri.Web.ViewModels.Course;

namespace Capri.Services.Courses
{
    public class CourseUpdater : ICourseUpdater
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;

        public CourseUpdater(
            ISqlDbContext context, 
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IServiceResult<CourseView>> Update(
            Guid id, 
            CourseRegistration newData)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id.Equals(id));

            if (course == null)
            {
                return ServiceResult<CourseView>.Error("There is no course with id " + id);
            }

            course = _mapper.Map(newData, course);

            _context.Courses.Update(course);
            await _context.SaveChangesAsync();

            var courseView = _mapper.Map<CourseView>(course);
            return ServiceResult<CourseView>.Success(courseView);
        }
    }
}