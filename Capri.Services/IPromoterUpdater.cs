using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Capri.Database.Entities;
using Capri.Web.ViewModels.Promoter;

namespace Capri.Services
{
    public interface IPromoterUpdater
    {
        Task<IServiceResult<Promoter>> Update(PromoterUpdate newData);
    }
}
