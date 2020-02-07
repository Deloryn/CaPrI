using System;
using System.Threading.Tasks;
using Capri.Database.Entities;

namespace Capri.Services.Proposals
{
    public interface ISubmittedProposalGetter
    {
        Task<IServiceResult<int>> CountSubmittedProposals(
            int promoterId, 
            StudyLevel level);
    }
}
