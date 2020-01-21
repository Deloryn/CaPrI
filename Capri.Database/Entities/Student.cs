using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Capri.Database.Entities.Identity;

namespace Capri.Database.Entities
{
    public class Student : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public ushort Semester { get; set; }
        [Required]
        public StudyLevel StudyLevel { get; set; }
        [Required]
        public StudyMode StudyMode { get; set; }
        [Required]
        [ForeignKey("ApplicationUser")]
        public Guid UserId { get; set; }
        public virtual User ApplicationUser { get; set; }
        public Guid? ProposalId { get; set; }
        [ForeignKey("ProposalId")]
        public virtual Proposal Proposal { get; set; }
    }
}
