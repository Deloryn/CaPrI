using System;
using System.Collections.Generic;
using System.Text;

namespace Capri.Web.ViewModels.Promoter
{
    public class PromoterUpdate
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<Guid> ProposalsIds { get; set; }
        public bool CanSubmitBachelorProposals { get; set; }
        public bool CanSubmitMasterProposals { get; set; }
    }
}
