using System;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using Capri.Database;
using Capri.Services.Faculties;
using Capri.Web.ViewModels.Course;

namespace Capri.Services.Courses
{
    public class CourseUpdater : ICourseUpdater
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFacultyGetter _facultyGetter;

        public CourseUpdater(
            ISqlDbContext context, 
            IMapper mapper,
            IFacultyGetter facultyGetter)
        {
            _context = context;
            _mapper = mapper;
            _facultyGetter = facultyGetter;
        }

        public async Task<IServiceResult<CourseViewModel>> Update(
            Guid id, 
            CourseRegistration newData)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);

            if (course == null)
            {
                return ServiceResult<CourseViewModel>.Error(
                    $"Course with id {id} does not exist");
            }

            var facultyResult = await _facultyGetter.Get(newData.FacultyId);
            if(!facultyResult.Successful())
            {
                return ServiceResult<CourseViewModel>.Error(facultyResult.GetAggregatedErrors());
            }

            course = _mapper.Map(newData, course);

            _context.Courses.Update(course);
            await _context.SaveChangesAsync();

            var courseViewModel = _mapper.Map<CourseViewModel>(course);
            return ServiceResult<CourseViewModel>.Success(courseViewModel);
        }
    }
}