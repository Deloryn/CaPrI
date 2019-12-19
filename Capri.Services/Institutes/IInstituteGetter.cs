using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Capri.Web.ViewModels.Institute;

namespace Capri.Services.Institutes
{
    public interface IInstituteGetter
    {
        Task<IServiceResult<InstituteView>> Get(Guid id);
        IServiceResult<IEnumerable<InstituteView>> GetAll();
    }
}