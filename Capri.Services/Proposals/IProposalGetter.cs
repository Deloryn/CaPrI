using Capri.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capri.Services
{
    public interface IProposalGetter
    {
        Task<IServiceResult<Proposal>> Get(Guid id);

        IServiceResult<IEnumerable<Proposal>> GetAll();
    }
}
