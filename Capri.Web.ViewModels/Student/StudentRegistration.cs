using System;
using System.ComponentModel.DataAnnotations;
using Capri.Database.Entities;

namespace Capri.Web.ViewModels.Student
{
    public class StudentRegistration
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [MaxLength(24)]
        public string Password { get; set; }
        
        [Required]
        [Range(1,7)]
        public ushort Semester { get; set; }

        [Required]
        [EnumDataType(typeof(StudyLevel))]
        public StudyLevel StudyLevel { get; set; }

        [Required]
        [EnumDataType(typeof(StudyMode))]
        public StudyMode StudyMode { get; set; }

        public Guid? ProposalId { get; set; }
    }
}