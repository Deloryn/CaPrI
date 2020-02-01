using System;
using System.Collections.Generic;

namespace Capri.Web.ViewModels.Course
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FacultyId { get; set; }
        public ICollection<int> Proposals { get; set; }
    }
}