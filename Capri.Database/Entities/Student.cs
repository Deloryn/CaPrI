using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public ushort Semester;
        [Required]
        public StudyLevel StudyLevel;
        [ForeignKey("ApplicationUser")]
        public Guid UserId { get; set; }
        public virtual User ApplicationUser { get; set; }
    }
}
