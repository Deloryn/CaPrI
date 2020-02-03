using AutoMapper;
using PUT.WebServices.eDziekanatServiceClient;
using StudyScopeElement = PUT.WebServices.eDziekanatServiceClient.eDziekanatService.StudyScopeElement;
using Capri.Database;
using Capri.Database.Entities;

namespace Capri.Synchronizer.Synchronizers
{
    public class CourseSynchronizer : ICourseSynchronizer
    {
        private readonly IEDziekanatClient _eDziekanatClient;
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;

        public CourseSynchronizer(
            IEDziekanatClient eDziekanatClient, 
            ISqlDbContext context,
            IMapper mapper)
        {
            _eDziekanatClient = eDziekanatClient;
            _context = context;
            _mapper = mapper;
        }

        public void Synchronize() {
            // var faculties = _context.Faculties;
            // foreach(var faculty in faculties) {
            //     var studyScopeElements = _eDziekanatClient.GetFacultyStudies(faculty.Id, true);
            //     foreach(var studyScopeElement in studyScopeElements)
            //     {
            //         var course = _mapper.Map<Course>(studyScopeElement);
            //         course.FacultyId = faculty.Id;
            //         _context.Courses.Add(course);
            //     }
            // }
            // _context.SaveChanges();
        }
    }
}