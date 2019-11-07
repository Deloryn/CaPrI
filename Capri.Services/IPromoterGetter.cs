using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Capri.Database.Entities;

namespace Capri.Services
{
    public interface IPromoterGetter
    {
        Task<IServiceResult<Promoter>> Get(Guid id);
        IServiceResult<IEnumerable<Promoter>> GetAll();
    }
}
