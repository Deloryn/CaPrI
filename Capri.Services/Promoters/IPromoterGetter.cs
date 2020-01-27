using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capri.Web.ViewModels.Promoter;

namespace Capri.Services.Promoters
{
    public interface IPromoterGetter
    {
        Task<IServiceResult<PromoterViewModel>> Get(Guid id);
        IServiceResult<IEnumerable<PromoterViewModel>> GetAll();
        Task<IServiceResult<PromoterViewModel>> GetMyData();
    }
}
