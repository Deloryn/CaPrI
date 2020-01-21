using System;
using CsvHelper.Configuration.Attributes;

namespace Capri.Web.ViewModels.Proposal
{
    public class ProposalCsvRecord
    {
        [Name("Id")]
        public Guid Id { get; set; }

        [Name("Tytuł")]
        public string TopicPolish { get; set; }

        [Name("Tytuł Ang.")]
        public string TopicEnglish { get; set; }

        [Name("Opis")]
        public string Description { get; set; }

        [Name("Dane wyjściowe")]
        public string OutputData { get; set; }

        [Name("Specjalność")]
        public string Specialization { get; set; }

        [Name("Data rozpoczęcia")]
        public DateTime StartingDate { get; set; }

        [Name("Status")]
        public string Status { get; set; }

        [Name("Poziom studiów")]
        public string Level { get; set; }

        [Name("Tryb studiów")]
        public string Mode { get; set; }

        [Name("Profil kształcenia")]
        public string StudyProfile { get; set; }
        
        [Name("Maks. liczba studentów")]
        public int MaxNumberOfStudents { get; set; }

        [Name("Promotor")]
        public string Promoter { get; set; }

        [Name("Kierunek")]
        public string Course { get; set; }

        [Name("Wydział")]
        public string Faculty { get; set; }

        [Name("Instytut")]
        public string Institute { get; set; }
    }
}
