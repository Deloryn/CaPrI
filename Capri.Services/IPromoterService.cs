using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Capri.Database.Entities;
using Capri.Web.ViewModels.Promoter;

namespace Capri.Services
{
    public interface IPromoterService
    {
        IServiceResult<Promoter> Create(PromoterRegistration promoterRegistration);
        IServiceResult<Promoter> Get(Guid id);
        IServiceResult<List<Promoter>> GetAll();
        IServiceResult<Promoter> Update(PromoterUpdate newData);
        IServiceResult<Promoter> Delete(Guid id);
    }
}
