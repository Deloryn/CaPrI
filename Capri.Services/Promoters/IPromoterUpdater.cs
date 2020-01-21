using System;
using System.Threading.Tasks;
using Capri.Web.ViewModels.Promoter;

namespace Capri.Services.Promoters
{
    public interface IPromoterUpdater
    {
        Task<IServiceResult<PromoterViewModel>> Update(Guid id, PromoterRegistration newData);
    }
}
