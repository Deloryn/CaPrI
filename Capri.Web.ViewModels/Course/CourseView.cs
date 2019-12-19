using System;
using System.Collections.Generic;

namespace Capri.Web.ViewModels.Course
{
    public class CourseView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid FacultyId { get; set; }
        public ICollection<Guid> Proposals { get; set; }
    }
}