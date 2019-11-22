using System;
using System.Collections.Generic;
using System.Text;
using Capri.Database.Entities;

namespace Capri.Web.ViewModels.Proposal
{
    public class ProposalRegistration
    {
        public string Topic { get; set; }
        public string Description { get; set; }
        public ProposalStatus Status { get; set; }
        public StudyLevel Level { get; set; }
    }
}
