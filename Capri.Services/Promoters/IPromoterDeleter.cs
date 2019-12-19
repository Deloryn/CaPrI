using System;
using System.Threading.Tasks;
using Capri.Web.ViewModels.Promoter;

namespace Capri.Services.Promoters
{
    public interface IPromoterDeleter
    {
        Task<IServiceResult<PromoterView>> Delete(Guid id);
    }
}
