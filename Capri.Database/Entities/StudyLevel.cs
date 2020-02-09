using System.ComponentModel;

namespace Capri.Database.Entities
{
    public enum StudyLevel
    {
        [Description("Studia inżynierskie")]
        Bachelor = 0,
        [Description("Studia magisterskie")]
        Master = 1
    };
}