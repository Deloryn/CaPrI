using System;
using System.Collections.Generic;
using System.Text;
using Capri.Database.Entities;

namespace Capri.Web.ViewModels.Proposal
{
    public class ProposalDocRecord
    {
        public string College { get; set; } = "Politechnika Poznańska";//
        public string Faculty { get; set; }// faculty chyba nie potrzebne bo znajduje sie w course
        public string Course { get; set; }// to jest w proposal
        public string Specialization { get; set; }//
        public string StudyProfile { get; set; }// to jest w proposal
        public string Mode { get; set; }// to jest w proposal StudyMode
        public string Level { get; set; }// to jest w proposal StudyLevel
        public ICollection<Student> Students { get; set; }// to jest w proposal
        public string TopicPolish { get; set; }//
        public string TopicEnglish { get; set; }//
        public string OutputData { get; set; }//
        public string Description { get; set; }//
        public DateTime StartingDate { get; set; }// tego nie ma a potrzebny koniec
        public string Promoter { get; set; }//
        public string Institute { get; set; }// promoter ma institute
    }
}
