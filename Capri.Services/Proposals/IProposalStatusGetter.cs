using Capri.Database.Entities;

namespace Capri.Services.Proposals
{
    public interface IProposalStatusGetter
    {
        IServiceResult<ProposalStatus> CalculateProposalStatus(Proposal proposal);
    }
}