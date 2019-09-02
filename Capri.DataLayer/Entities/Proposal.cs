using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capri.DataLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace Capri.DataLayer.Entities
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
        public StatusEnum Status { get; set; }
        public ICollection<Student> AssignedStudents { get; set; }
        public ICollection<Student> WillingCandidates { get; set; }
    }

    public enum StatusEnum
    {
        Taken = 0,
        Available = 1
    }
}
