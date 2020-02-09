using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Capri.Database.Entities.Identity;

namespace Capri.Database.Entities
{
    public class Promoter : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public string TitlePrefix { get; set; }
        public string TitlePostfix { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int ExpectedNumberOfBachelorProposals { get; set; }
        [Required]
        public int ExpectedNumberOfMasterProposals { get; set; }
        public virtual ICollection<Proposal> Proposals { get; set; }
        [Required]
        [ForeignKey("ApplicationUser")]
        public int UserId { get; set; }
        public virtual User ApplicationUser { get; set; }
        [Required]
        public int InstituteId { get; set; }
        [ForeignKey("InstituteId")]
        public virtual Institute Institute { get; set; }
    }
}
