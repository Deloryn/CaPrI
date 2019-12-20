﻿using System;
using System.Collections.Generic;

namespace Capri.Web.ViewModels.Promoter
{
    public class PromoterView
    {
        public Guid Id { get; set; }
        public string TitlePrefix { get; set; }
        public string TitlePostfix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ExpectedNumberOfBachelorProposals { get; set; }
        public int ExpectedNumberOfMasterProposals { get; set; }
        public virtual ICollection<Guid> Proposals { get; set; }
        public Guid UserId { get; set; }
        public Guid InstituteId { get; set; }
    }
}
