using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Capri.Database.Entities;

namespace Capri.Services
{
    public interface IPromoterDeleter
    {
        Task<IServiceResult<Promoter>> Delete(Guid id);
    }
}
