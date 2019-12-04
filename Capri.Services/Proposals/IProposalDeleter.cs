using System;
using System.Threading.Tasks;
using Capri.Database.Entities;

namespace Capri.Services.Proposals
{
    public interface IProposalDeleter
    {
        Task<IServiceResult<Proposal>> Delete(Guid id);
    }
}
