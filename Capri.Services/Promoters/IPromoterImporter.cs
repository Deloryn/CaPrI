using Capri.Web.ViewModels.Promoter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capri.Services.Promoters
{
    public interface IPromoterImporter
    {
        Task<IServiceResult<int>> Import(IEnumerable<PromoterJsonRecord> promoterRegistration);
    }
}
