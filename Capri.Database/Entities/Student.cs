using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Capri.Database.Entities.Identity;

namespace Capri.Database.Entities
{
    public class Student : User
    {
        [Required]
        public int Semester;
        [Required]
        public StudyLevelEnum StudyLevel;
    }
}
