using System.ComponentModel.DataAnnotations;

namespace Capri.Web.ViewModels.Faculty
{
    public class FacultyRegistration
    {
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}