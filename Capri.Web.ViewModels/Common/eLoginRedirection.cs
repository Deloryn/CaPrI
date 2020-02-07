using System.ComponentModel.DataAnnotations;

namespace Capri.Web.ViewModels.Common
{
    public class eLoginRedirection
    {
        public string Version { get; set; }
        public string Language { get; set; }
        [Required]
        [MinLength(1)]
        public string SessionAuthorizationKey { get; set; }
    }
}