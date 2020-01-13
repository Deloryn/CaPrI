using System;
using Capri.Database.Entities;

namespace Capri.Web.ViewModels.Student
{
    public class StudentViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public ushort Semester { get; set; }
        public StudyLevel StudyLevel { get; set; }
        public StudyMode StudyMode;
        public Guid? ProposalId { get; set; }
    }
}