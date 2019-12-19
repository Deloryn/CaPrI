using System.Threading.Tasks;
using AutoMapper;
using Capri.Database;
using Capri.Database.Entities;
using Capri.Services.Faculties;
using Capri.Web.ViewModels.Course;

namespace Capri.Services.Courses
{
    public class CourseCreator : ICourseCreator
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFacultyGetter _facultyGetter;

        public CourseCreator(
            ISqlDbContext context,
            IMapper mapper,
            IFacultyGetter facultyGetter
        )
        {
            _context = context;
            _mapper = mapper;
            _facultyGetter = facultyGetter;
        }

        public async Task<IServiceResult<CourseView>> Create(CourseRegistration registration)
        {
            var facultyResult = await _facultyGetter.Get(registration.FacultyId);
            if(!facultyResult.Successful())
            {
                return ServiceResult<CourseView>.Error(facultyResult.GetAggregatedErrors());
            }

            var course = _mapper.Map<Course>(registration);

            try 
            {
                await _context.Courses.AddAsync(course);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return ServiceResult<CourseView>.Error(
                    "Failed to create a course from the given data");
            }

            var courseView = _mapper.Map<CourseView>(course);
            return ServiceResult<CourseView>.Success(courseView);
        }
    }
}