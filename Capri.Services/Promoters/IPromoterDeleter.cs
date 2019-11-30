using System;
using System.Threading.Tasks;
using Capri.Database.Entities;

namespace Capri.Services.Promoters
{
    public interface IPromoterDeleter
    {
        Task<IServiceResult<Promoter>> Delete(Guid id);
    }
}
