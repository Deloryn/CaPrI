using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Capri.Database.Entities
{
    public abstract class Proposal : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Topic { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public ProposalStatusEnum Status { get; set; }
        public virtual ICollection<Student> AssignedStudents { get; set; }
        public virtual ICollection<Student> WillingCandidates { get; set; }
    }
}
