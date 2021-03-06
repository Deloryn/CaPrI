﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Capri.Database.Entities;

namespace Capri.Web.ViewModels.Proposal
{
    public class ProposalRegistration
    {
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string TopicPolish { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string TopicEnglish { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(1000)]
        public string Description { get; set; }

        [MaxLength(1000)]
        public string OutputData { get; set; }

        [MaxLength(50)]
        public string Specialization { get; set; }

        [Required]
        [Range(1, 4)]
        public int MaxNumberOfStudents { get; set; }

        [EnumDataType(typeof(StudyProfile))]
        public StudyProfile StudyProfile { get; set; }

        [EnumDataType(typeof(StudyLevel))]
        public StudyLevel Level { get; set; }

        [EnumDataType(typeof(StudyMode))]
        public StudyMode Mode { get; set; }

        [Required]
        public int CourseId { get; set; }
        public ICollection<int> Students { get; set; }
    }
}
