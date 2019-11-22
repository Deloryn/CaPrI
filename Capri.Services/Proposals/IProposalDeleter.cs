using Capri.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capri.Services.Proposals
{
    public interface IProposalDeleter
    {
        Task<IServiceResult<Proposal>> Delete(Guid id);
    }
}
