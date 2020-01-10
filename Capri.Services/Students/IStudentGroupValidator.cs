using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capri.Services.Students
{
    public interface IStudentGroupValidator
    {
        Task<IServiceResult<bool>> DoStudentsExist(IEnumerable<Guid> studentIds);
    }
}