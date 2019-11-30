using System.Threading.Tasks;
using Capri.Database.Entities;
using Capri.Web.ViewModels.Proposal;

namespace Capri.Services.Proposals
{
    public interface IProposalCreator
    {
        Task<IServiceResult<Proposal>> Create(ProposalRegistration proposalRegistration);
    }
}
