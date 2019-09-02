using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Capri.DataLayer.Entities
{
    public class Student : User
    {
        [Required]
        public int Semester;
        [Required]
        public StudyLevelEnum StudyLevel;
    }

    public enum StudyLevelEnum
    {
        Bachelor = 0,
        Master = 1
    };
}
