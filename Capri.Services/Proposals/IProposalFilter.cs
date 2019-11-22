using System.Collections.Generic;
using Capri.Database.Entities;
using Capri.Web.ViewModels.Proposal;

namespace Capri.Services.Proposals
{
    public interface IProposalFilter
    {
        IServiceResult<IEnumerable<Proposal>> Filter(
            ProposalFilterModel filter, 
            IEnumerable<Proposal> proposals);
    }
}