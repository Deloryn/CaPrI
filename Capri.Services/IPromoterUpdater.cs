using System;
using System.Collections.Generic;
using System.Text;
using Capri.Database.Entities;
using Capri.Web.ViewModels.Promoter;

namespace Capri.Services
{
    public interface IPromoterUpdater
    {
        IServiceResult<Promoter> Update(PromoterUpdate newData);
    }
}
