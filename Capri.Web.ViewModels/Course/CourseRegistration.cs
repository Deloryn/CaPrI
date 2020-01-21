using System;
using System.ComponentModel.DataAnnotations;

namespace Capri.Web.ViewModels.Course
{
    public class CourseRegistration
    {
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public Guid FacultyId { get; set; }
    }
}