using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Capri.Database;
using Capri.Database.Entities;
using Capri.Web.ViewModels.Course;

namespace Capri.Services.Courses
{
    public class CourseCreator : ICourseCreator
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;

        public CourseCreator(
            ISqlDbContext context,
            IMapper mapper
        )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IServiceResult<CourseViewModel>> Create(CourseRegistration registration)
        {
            var faculty = await _context
                .Faculties
                .Include(f => f.Courses)
                .FirstOrDefaultAsync(f => f.Id == registration.FacultyId);

            if(faculty == null)
            {
                return ServiceResult<CourseViewModel>.Error(
                    $"Faculty with id {registration.FacultyId} does not exist"
                );
            }

            if(IsCourseNameOnFacultyTaken(registration.Name, faculty))
            {
                return ServiceResult<CourseViewModel>.Error(
                    $"Faculty with id {faculty.Id} already has a course with name {registration.Name}"
                );
            }

            var course = _mapper.Map<Course>(registration);

            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();

            var courseViewModel = _mapper.Map<CourseViewModel>(course);
            return ServiceResult<CourseViewModel>.Success(courseViewModel);
        }

        private bool IsCourseNameOnFacultyTaken(string name, Faculty faculty)
        {
            return faculty.Courses.Any(c => c.Name == name);
        }
    }
}