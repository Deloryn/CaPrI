using Capri.Database.Entities;

namespace Capri.Web.ViewModels.Proposal
{
    public class ProposalFilterModel
    {
        public string Title { get; set; }
        public string PromoterLastName { get; set; }
        public string Status { get; set; }
        public string Level { get; set; }
        public string Mode { get; set; }
        public string SortBy { get; set; }
        public string Order { get; set; }
        public int Page { get; set; }  
        public int Limit { get; set; }
    }
}