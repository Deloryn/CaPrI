using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Capri.Database;
using Capri.Web.ViewModels.Course;

namespace Capri.Services.Courses
{
    public class CourseGetter : ICourseGetter
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
        
        public CourseGetter(
            ISqlDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IServiceResult<CourseViewModel>> Get(Guid id)
        {
            var course = await _context.Courses
                .Include(c => c.Proposals)
                .FirstOrDefaultAsync(c => c.Id.Equals(id));

            if(course == null)
            {
                return ServiceResult<CourseViewModel>.Error(
                    $"Course with id {id} does not exist");
            }

            var courseViewModel = _mapper.Map<CourseViewModel>(course);
            return ServiceResult<CourseViewModel>.Success(courseViewModel);
        }
        public IServiceResult<IEnumerable<CourseViewModel>> GetAll()
        {
            var courses = _context.Courses
                .Include(c => c.Proposals);
            
            var courseViewModels = courses.Select(c => _mapper.Map<CourseViewModel>(c));
            return ServiceResult<IEnumerable<CourseViewModel>>.Success(courseViewModels);
        }
    }
}