using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capri.Web.ViewModels.Promoter;

namespace Capri.Services.Promoters
{
    public interface IPromoterGetter
    {
        Task<IServiceResult<PromoterView>> Get(Guid id);
        IServiceResult<IEnumerable<PromoterView>> GetAll();
    }
}
