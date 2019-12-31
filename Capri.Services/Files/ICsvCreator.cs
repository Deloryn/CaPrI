using System.Collections.Generic;

namespace Capri.Services.Files
{
    public interface ICsvCreator
    {
        IServiceResult<string> CreateCsvStringFrom<T>(IEnumerable<T> records);
    }
}