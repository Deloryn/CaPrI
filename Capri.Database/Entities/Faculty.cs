using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Capri.Database.Entities
{
    public class Faculty : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}