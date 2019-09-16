using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Capri.Database.Entities.Identity;

namespace Capri.Database.Entities
{
    public class Student
    {
        [Required]
        public ushort Semester;
        [Required]
        public StudyLevelEnum StudyLevel;
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
