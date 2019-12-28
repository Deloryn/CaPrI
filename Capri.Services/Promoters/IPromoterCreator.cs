using System.Threading.Tasks;
using Capri.Web.ViewModels.Promoter;

namespace Capri.Services.Promoters
{
    public interface IPromoterCreator
    {
        Task<IServiceResult<PromoterViewModel>> Create(PromoterRegistration promoterRegistration);
    }
}
