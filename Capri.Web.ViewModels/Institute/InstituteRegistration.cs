using System.ComponentModel.DataAnnotations;

namespace Capri.Web.ViewModels.Institute
{
    public class InstituteRegistration
    {
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}