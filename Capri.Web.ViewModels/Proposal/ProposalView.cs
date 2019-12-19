using System;
using System.Collections.Generic;
using System.Text;
using Capri.Database.Entities;

namespace Capri.Web.ViewModels.Proposal
{
    public class ProposalView
    {
        public Guid Id { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public ProposalStatus Status { get; set; }
        public StudyLevel Level { get; set; }
        public StudyMode Mode { get; set; }
        public Guid PromoterId { get; set; }
        public virtual ICollection<Guid> Students { get; set; }
    }
}
