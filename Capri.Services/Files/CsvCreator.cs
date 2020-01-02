using System.IO;
using System.Collections.Generic;
using CsvHelper;

namespace Capri.Services.Files
{
    public class CsvCreator : ICsvCreator
    {
        public IServiceResult<string> CreateCsvStringFrom<T>(IEnumerable<T> records)
        {
            using(var stringWriter = new StringWriter())
            using(var csvWriter = new CsvWriter(stringWriter))
            {
                csvWriter.WriteHeader(typeof(T));
                csvWriter.NextRecord();
                csvWriter.WriteRecords(records);
                var csvString = stringWriter.ToString();
                return ServiceResult<string>.Success(csvString);
            }
        }
    }
}