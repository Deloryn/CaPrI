using System.Threading.Tasks;
using Capri.Web.ViewModels.Proposal;

namespace Capri.Services.Proposals
{
    public interface IProposalCreator
    {
        Task<IServiceResult<ProposalViewModel>> Create(
            ProposalRegistration inputData);
    }
}
