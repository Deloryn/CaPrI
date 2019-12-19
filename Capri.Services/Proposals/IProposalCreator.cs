using System.Threading.Tasks;
using Capri.Web.ViewModels.Proposal;

namespace Capri.Services.Proposals
{
    public interface IProposalCreator
    {
        Task<IServiceResult<ProposalView>> Create(
            ProposalRegistration inputData);
    }
}
