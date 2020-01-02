using System.ComponentModel;

namespace Capri.Database.Entities
{
    public enum StudyMode
    {
        [Description("Dzienne")]
        FullTime = 0,
        [Description("Zaoczne")]
        PartTime = 1
    };
}