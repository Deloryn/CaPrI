using System;
using System.Collections.Generic;

namespace Capri.Web.ViewModels.Faculty
{
    public class FacultyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<int> Courses { get; set; }
    }
}