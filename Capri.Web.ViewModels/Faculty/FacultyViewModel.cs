using System;
using System.Collections.Generic;

namespace Capri.Web.ViewModels.Faculty
{
    public class FacultyViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Guid> Courses { get; set; }
    }
}