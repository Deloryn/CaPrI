using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Capri.Database.Entities.Identity;

namespace Capri.Database.Entities
{
    public class Promoter : User
    {
        public virtual ICollection<Proposal> Proposals { get; set; }
        [Required]
        public bool CanSubmitBachelorProposals { get; set; }
    }
}
