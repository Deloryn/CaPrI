using System.Threading.Tasks;
using Capri.Database.Entities;
using Capri.Web.ViewModels.Promoter;

namespace Capri.Services.Promoters
{
    public interface IPromoterCreator
    {
        Task<IServiceResult<Promoter>> Create(PromoterRegistration promoterRegistration);
    }
}
