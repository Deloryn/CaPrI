using System.ComponentModel.DataAnnotations;

namespace Capri.Web.ViewModels.Common
{
    public class VueRedirection
    {
        [Required]
        [MinLength(1)]
        public string SessionAuthorizationKey { get; set; }
    }
}