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
        public StudyLevel Level { get; set; }
        public StudyMode Mode { get; set; }
        public Guid PromoterId { get; set; }
        [ForeignKey("PromoterId")]
        public virtual Promoter Promoter { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
