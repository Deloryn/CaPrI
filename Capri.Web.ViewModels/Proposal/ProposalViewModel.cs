﻿using System.Collections.Generic;
using System;
using Capri.Database.Entities;

namespace Capri.Web.ViewModels.Proposal
{
    public class ProposalViewModel
    {
        public Guid Id { get; set; }
        public string TopicPolish { get; set; }
        public string TopicEnglish { get; set; }
        public DateTime StartingDate { get; set; }
        public string Description { get; set; }
        public string Specialization { get; set; }
        public ProposalStatus Status { get; set; }
        public StudyProfile StudyProfile { get; set; }
        public StudyLevel Level { get; set; }
        public StudyMode Mode { get; set; }
        public Guid PromoterId { get; set; }
        public Guid CourseId { get; set; }
        public ICollection<Guid> Students { get; set; }
    }
}
