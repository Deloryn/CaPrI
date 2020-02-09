using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sieve.Models;
using Capri.Web.ViewModels.Common;
using Capri.Web.ViewModels.Promoter;

namespace Capri.Services.Promoters
{
    public interface IPromoterGetter
    {
        Task<IServiceResult<PromoterViewModel>> Get(int id);
        IServiceResult<IEnumerable<PromoterViewModel>> GetAll();
        IServiceResult<IQueryable<PromoterViewModel>> GetFiltered(SieveModel sieveModel);
        IServiceResult<int> Count(SieveModel sieveModel);
        Task<IServiceResult<PromoterViewModel>> GetMyData();
        IServiceResult<FileDescription> GetAllWithJsonFormat();
    }
}
