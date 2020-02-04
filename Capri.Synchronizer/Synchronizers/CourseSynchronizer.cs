using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using PUT.WebServices.eDziekanatServiceClient;
using StudyScope = PUT.WebServices.eDziekanatServiceClient.eDziekanatService.StudyScope;
using StudyScopeElement = PUT.WebServices.eDziekanatServiceClient.eDziekanatService.StudyScopeElement;
using Capri.Database;
using Capri.Database.Entities;
using Capri.Synchronizer.Comparers;

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

        public void Synchronize() 
        {
            var faculties = _context.Faculties;
            foreach(var faculty in faculties)
            {
                var facultyCourseScopes = GetFilteredFacultyCourseScopes(faculty.Id);
                var newCourses = facultyCourseScopes
                    .Select(s => {
                        var course = _mapper.Map<Course>(s);
                        course.FacultyId = faculty.Id;
                        return course;
                    });

                DeleteObsoleteFacultyCourses(newCourses, faculty.Id);
                AddIfNotExistRange(newCourses);
            }
        }

        private void DeleteObsoleteFacultyCourses(IEnumerable<Course> newCourses, int facultyId)
        {
            var obsoleteCourses = GetObsoleteFacultyCourses(newCourses, facultyId);
            _context.Courses.RemoveRange(obsoleteCourses);
            _context.SaveChanges();
        }

        private IEnumerable<Course> GetObsoleteFacultyCourses(IEnumerable<Course> newCourses, int facultyId)
        {
            var courseEqualityComparer = new CourseEqualityComparer();
            return _context
                .Courses
                .Where(c => c.FacultyId == facultyId)
                .Where(c => !newCourses.Contains(c, courseEqualityComparer));
        }

        private void AddIfNotExistRange(IEnumerable<Course> courses)
        {
            foreach(var course in courses)
            {
                AddIfNotExists(course);
            }
            _context.SaveChanges();
        }

        private void AddIfNotExists(Course course)
        {
            if(_context.Courses.Any(c => c.Name == course.Name && c.FacultyId == course.FacultyId))
            {
                return;
            }
            else
            {
                _context.Courses.Add(course);
            }
        }

        private IEnumerable<StudyScope> GetFilteredFacultyCourseScopes(int facultyId)
        {
            var activeScopeSymbols = _eDziekanatClient
                .GetFacultyGroups(facultyId)
                .Select(group => group.studyScopeSymbol);

            return GetAllFacultyCourseScopes(facultyId)
                .Where(scope => activeScopeSymbols.Contains(scope.symbol))
                .Where(scope => scope.studyType.name != "III stopnia")
                .GroupBy(scope => scope.GetName(Language.Polish))
                .Select(group => group.FirstOrDefault());
        }

        private IEnumerable<StudyScope> GetAllFacultyCourseScopes(int facultyId)
        {
            var rootScopeElements = _eDziekanatClient
                .GetFacultyStudies(facultyId, true);
            
            return GetFacultyStudiesFromNthLevel(rootScopeElements, 2);
        }

        private IEnumerable<StudyScope> GetFacultyStudiesFromNthLevel(StudyScopeElement[] rootScopeElements, int n)
        {
            if(n == 0)
            {
                return rootScopeElements.Select(e => e.studyScope);
            }

            var studies = new List<StudyScope>();
            foreach(var element in rootScopeElements)
            {
                if(element.childStudyScopes == null)
                {
                    continue;
                }
                studies.AddRange(GetFacultyStudiesFromNthLevel(element.childStudyScopes, n-1));
            }
            return studies;
        }
    }
}