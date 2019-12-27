using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Capri.Database;
using Capri.Web.ViewModels.Course;

namespace Capri.Services.Courses
{
    public class CourseDeleter : ICourseDeleter
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICourseGetter _courseGetter;

        public CourseDeleter(
            ISqlDbContext context,
            IMapper mapper,
            ICourseGetter courseGetter
            )
        {
            _context = context;
            _mapper = mapper;
            _courseGetter = courseGetter;
        }

        public async Task<IServiceResult<CourseView>> Delete(Guid id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id.Equals(id));
            
            if(course == null)
            {
                return ServiceResult<CourseView>.Error(
                    $"Course with id {id} does not exist");
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            var courseView = _mapper.Map<CourseView>(course);
            return ServiceResult<CourseView>.Success(courseView);
        }
    }
}