using System;
using System.Collections.Generic;
using System.Text;

namespace Capri.Web.ViewModels.Promoter
{
    public class PromoterUpdate
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool CanSubmitBachelorProposals { get; set; }
        public bool CanSubmitMasterProposals { get; set; }
    }
}
