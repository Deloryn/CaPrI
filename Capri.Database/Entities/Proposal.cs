using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capri.Database.Entities
{
    public class Proposal : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string TopicPolish { get; set; }
        [Required]
        public string TopicEnglish { get; set; }
        [Required]
        public DateTime StartingDate { get; set; }
        [Required]
        public string Description { get; set; }
        public string Specialization { get; set; }
        public string OutputData { get; set; }
        [Required]
        public int MaxNumberOfStudents { get; set; }
        [Required]
        public ProposalStatus Status { get; set; }
        [Required]
        public StudyProfile StudyProfile { get; set; }
        [Required]
        public StudyLevel Level { get; set; }
        [Required]
        public StudyMode Mode { get; set; }
        [Required]
        public Guid PromoterId { get; set; }
        [ForeignKey("PromoterId")]
        public virtual Promoter Promoter { get; set; }
        [Required]
        public Guid CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
