using System.ComponentModel.DataAnnotations;

namespace Capri.Web.ViewModels.User
{
    public class UserCredentials
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [MaxLength(24)]
        public string Password { get; set; }
    }
}
