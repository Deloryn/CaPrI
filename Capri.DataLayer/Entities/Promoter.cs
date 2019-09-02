using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capri.DataLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace Capri.DataLayer.Entities
{
    public class Promoter : User
    {
        public ICollection<Proposal> Proposals { get; set; }
        [Required]
        public bool CanSubmitBachelorProposals { get; set; }
    }
}
