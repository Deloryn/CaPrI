using System;
using System.Collections.Generic;
using System.Text;
using Capri.Database.Entities;

namespace Capri.Services
{
    public interface IPromoterGetter
    {
        IServiceResult<Promoter> Get(Guid id);
        IServiceResult<List<Promoter>> GetAll();
    }
}
