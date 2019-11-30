using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capri.Database.Entities;

namespace Capri.Services.Promoters
{
    public interface IPromoterGetter
    {
        Task<IServiceResult<Promoter>> Get(Guid id);
        IServiceResult<IEnumerable<Promoter>> GetAll();
    }
}
