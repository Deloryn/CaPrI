using System.ComponentModel.DataAnnotations;

namespace Capri.Web.ViewModels.Common
{
    public class eLoginRedirection
    {
        public int Version { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(2)]
        public string Language { get; set; }

        [Required]
        [MinLength(1)]
        public string SessionAuthorizationKey { get; set; }
    }
}