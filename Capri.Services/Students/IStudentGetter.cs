using System.Collections.Generic;
using PUT.WebServices.eDziekanatServiceClient.eDziekanatService;

namespace Capri.Services.Students
{
    public interface IStudentGetter
    {
        IServiceResult<BasicStudentData[]> GetMany(ICollection<int> indexNumbers);
        IServiceResult<BasicStudentData[]> GetMany(string indexNumbersString);
    }
}