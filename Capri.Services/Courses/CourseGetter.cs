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

        public async Task<IServiceResult<CourseView>> Get(Guid id)
        {
            var course = await _context.Courses
                .Include(c => c.Proposals)
                .FirstOrDefaultAsync(c => c.Id.Equals(id));

            if(course == null)
            {
                return ServiceResult<CourseView>.Error("Course with id " + id + " does not exist");
            }

            var courseView = _mapper.Map<CourseView>(course);
            return ServiceResult<CourseView>.Success(courseView);
        }
        public IServiceResult<IEnumerable<CourseView>> GetAll()
        {
            var courses = _context.Courses
                .Include(c => c.Proposals);
            
            var courseViews = courses.Select(c => _mapper.Map<CourseView>(c));
            return ServiceResult<IEnumerable<CourseView>>.Success(courseViews);
        }
    }
}