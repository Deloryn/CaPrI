using System;
using System.Collections.Generic;
using System.Text;
using Capri.Database.Entities;

namespace Capri.Web.ViewModels.Proposal
{
    public class ProposalDocRecord
    {
        public string College { get; set; } = "Politechnika Poznańska";
        public string Faculty { get; set; }
        public string Course { get; set; }
        public string Specialization { get; set; }
        public string StudyProfile { get; set; }
        public string Mode { get; set; }
        public string Level { get; set; }
        public ICollection<int> StudentIndexes { get; set; }
        public string TopicPolish { get; set; }
        public string TopicEnglish { get; set; }
        public string OutputData { get; set; }
        public string Description { get; set; }
        public DateTime StartingDate { get; set; }
        public string Promoter { get; set; }
        public string Institute { get; set; }
    }
}
