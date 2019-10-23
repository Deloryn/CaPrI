using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capri.Database.Entities
{
    public class Proposal : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Topic { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public ProposalStatus Status { get; set; }
        [Required]
        public ProposalType Type { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
