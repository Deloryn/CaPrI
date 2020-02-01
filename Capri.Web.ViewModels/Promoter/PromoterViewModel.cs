using System;
using System.Collections.Generic;

namespace Capri.Web.ViewModels.Promoter
{
    public class PromoterViewModel
    {
        public int Id { get; set; }
        public string TitlePrefix { get; set; }
        public string TitlePostfix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ExpectedNumberOfBachelorProposals { get; set; }
        public int ExpectedNumberOfMasterProposals { get; set; }
        public ICollection<int> Proposals { get; set; }
        public int UserId { get; set; }
        public int InstituteId { get; set; }
    }
}
