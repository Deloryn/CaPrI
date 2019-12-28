using System;

namespace Capri.Web.ViewModels.Promoter
{
    public class PromoterRegistration
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string TitlePrefix { get; set; }
        public string TitlePostfix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ExpectedNumberOfBachelorProposals { get; set; }
        public int ExpectedNumberOfMasterProposals { get; set; }
        public Guid InstituteId { get; set; }
    }
}
