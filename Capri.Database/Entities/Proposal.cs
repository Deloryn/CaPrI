using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Capri.Database.Entities
{
    public abstract class Proposal
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Topic { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public ProposalStatusEnum Status { get; set; }
        public ICollection<Student> AssignedStudents { get; set; }
        public ICollection<Student> WillingCandidates { get; set; }
    }
}
