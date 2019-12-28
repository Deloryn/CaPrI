using System.Collections.Generic;

namespace Capri.Services.Files
{
    public interface ICsvCreator
    {
        IServiceResult<string> CreateCsvString<T>(IEnumerable<T> objectsToSerialize, char separator);
    }
}