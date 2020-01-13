using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Capri.Database;
using Capri.Database.Entities;
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

            var faculty = await _context
                .Faculties
                .Include(f => f.Courses)
                .FirstOrDefaultAsync(f => f.Id == newData.FacultyId);

            if(faculty == null)
            {
                return ServiceResult<CourseViewModel>.Error(
                    $"Faculty with id {newData.FacultyId} does not exist"
                );
            }

            if(IsAnotherSuchCourseNameOnFaculty(course.Id, newData.Name, faculty))
            {
                return ServiceResult<CourseViewModel>.Error(
                    $"Faculty with id {faculty.Id} already has a course with name {newData.Name}"
                );
            }

            course = _mapper.Map(newData, course);

            _context.Courses.Update(course);
            await _context.SaveChangesAsync();

            var courseViewModel = _mapper.Map<CourseViewModel>(course);
            return ServiceResult<CourseViewModel>.Success(courseViewModel);
        }

        private bool IsAnotherSuchCourseNameOnFaculty(Guid myCourseId, string name, Faculty faculty)
        {
            return faculty.Courses.Any(c => c.Name == name && c.Id != myCourseId);
        }
    }
}