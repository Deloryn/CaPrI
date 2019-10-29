﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Capri.Database.Entities.Identity;

namespace Capri.Database.Entities
{
    public class Promoter : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public virtual ICollection<Proposal> Proposals { get; set; }
        [Required]
        public bool CanSubmitBachelorProposals { get; set; }
        [Required]
        public bool CanSubmitMasterProposals { get; set; }
        [ForeignKey("ApplicationUser")]
        public Guid UserId { get; set; }
        public virtual User ApplicationUser { get; set; }
    }
}