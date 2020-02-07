using System.Collections.Generic;
using Capri.Database.Entities;

namespace Capri.Synchronizer.Comparers
{
    public class CourseEqualityComparer : IEqualityComparer<Course>
    {
        public bool Equals(Course c1, Course c2)
        {
            return c1.FacultyId == c2.FacultyId && c1.Name == c2.Name;
        }

        public int GetHashCode(Course course)
        {
            return course.Name.GetHashCode() * course.FacultyId.GetHashCode();
        }
    }
}