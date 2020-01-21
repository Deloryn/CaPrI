using System;
using System.Collections.Generic;
using System.Text;

namespace Capri.Services
{
    public interface IServiceResult<T>
    {
        bool Successful();
        bool IsValid();
        IEnumerable<string> GetAggregatedErrors();
        T Body();
    }
}
