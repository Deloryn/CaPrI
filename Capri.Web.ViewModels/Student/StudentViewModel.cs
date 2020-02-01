using System;
using Capri.Database.Entities;

namespace Capri.Web.ViewModels.Student
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int IndexNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ushort Semester { get; set; }
        public StudyLevel StudyLevel { get; set; }
        public StudyMode StudyMode;
        public int? ProposalId { get; set; }
    }
}