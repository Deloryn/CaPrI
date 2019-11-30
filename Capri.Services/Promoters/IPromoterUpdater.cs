using System;
using System.Threading.Tasks;
using Capri.Database.Entities;
using Capri.Web.ViewModels.Promoter;

namespace Capri.Services.Promoters
{
    public interface IPromoterUpdater
    {
        Task<IServiceResult<Promoter>> Update(Guid id, PromoterUpdate newData);
    }
}
