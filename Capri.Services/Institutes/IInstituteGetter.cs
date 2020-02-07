using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Capri.Web.ViewModels.Institute;

namespace Capri.Services.Institutes
{
    public interface IInstituteGetter
    {
        Task<IServiceResult<InstituteViewModel>> Get(int id);
        IServiceResult<IEnumerable<InstituteViewModel>> GetAll();
    }
}