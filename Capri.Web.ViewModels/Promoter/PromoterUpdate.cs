using System.ComponentModel.DataAnnotations;

namespace Capri.Web.ViewModels.Promoter
{
    public class PromoterUpdate
    {
        [Required]
        [Range(0, 10)]
        public int ExpectedNumberOfBachelorProposals { get; set; }

        [Required]
        [Range(0, 10)]
        public int ExpectedNumberOfMasterProposals { get; set; }
    }
}
