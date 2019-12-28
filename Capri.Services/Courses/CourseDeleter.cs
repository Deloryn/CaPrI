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

        public async Task<IServiceResult<CourseViewModel>> Delete(Guid id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            
            if(course == null)
            {
                return ServiceResult<CourseViewModel>.Error(
                    $"Course with id {id} does not exist");
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            var courseViewModel = _mapper.Map<CourseViewModel>(course);
            return ServiceResult<CourseViewModel>.Success(courseViewModel);
        }
    }
}