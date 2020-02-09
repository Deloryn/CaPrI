using System.ComponentModel;

namespace Capri.Database.Entities
{
    public enum ProposalStatus
    {
        [Description("Zajęty")]
        Taken = 0,
        [Description("Częściowo zajęty")]
        PartiallyTaken = 1,
        [Description("Wolny")]
        Free = 2,
        Overloaded = 3
    };
}