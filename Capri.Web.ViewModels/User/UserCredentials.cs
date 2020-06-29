using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Capri.Web.ViewModels.User
{
    public class UserCredentials
    {
        [Required]
        [EmailAddressAttribute]
        public string Email { get; set; }

        [Required]
        [PasswordPropertyTextAttribute]
        public string Password { get; set; }
    }
}
