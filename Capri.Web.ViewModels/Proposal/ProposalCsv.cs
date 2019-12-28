using System;
using System.ComponentModel;

namespace Capri.Web.ViewModels.Proposal
{
    public class ProposalCsv
    {
        [Description("Id")]
        public Guid Id { get; set; }

        [Description("Tytuł")]
        public string TopicPolish { get; set; }

        [Description("Tytuł Ang.")]
        public string TopicEnglish { get; set; }

        [Description("Opis")]
        public string Description { get; set; }

        [Description("Dane wyjściowe")]
        public string OutputData { get; set; }

        [Description("Specjalność")]
        public string Specialization { get; set; }

        [Description("Data rozpoczęcia")]
        public DateTime StartingDate { get; set; }

        [Description("Status")]
        public string Status { get; set; }

        [Description("Poziom studiów")]
        public string Level { get; set; }

        [Description("Tryb studiów")]
        public string Mode { get; set; }

        [Description("Profil kształcenia")]
        public string StudyProfile { get; set; }

        [Description("Promotor")]
        public string Promoter { get; set; }

        [Description("Kierunek")]
        public string Course { get; set; }

        [Description("Wydział")]
        public string Faculty { get; set; }

        [Description("Instytut")]
        public string Institute { get; set; }
    }
}
