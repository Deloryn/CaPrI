using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Capri.Database.Entities
{
    public class Promoter : User
    {
        public ICollection<Proposal> Proposals { get; set; }
        [Required]
        public bool CanSubmitBachelorProposals { get; set; }
    }
}
