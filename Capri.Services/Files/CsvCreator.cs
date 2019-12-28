using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Capri.Services.Files
{
    public class CsvCreator : ICsvCreator
    {
        public IServiceResult<string> CreateCsvString<T>(IEnumerable<T> objectsToSerialize, char separator)
        {   
            var builder = new StringBuilder();

            WriteHeader(builder, separator, typeof(T));
            WriteData(builder, separator, objectsToSerialize);

            var csvString = builder.ToString();
            return ServiceResult<string>.Success(csvString);
        }


        private void WriteHeader(StringBuilder builder, char separator, Type type)
        {
            var properties = type.GetProperties();
            var propertyDescriptions = properties.Select(p => GetDescriptionOf(p));
            var header = String.Join(separator, propertyDescriptions);
            builder.AppendLine(header);
        }

        private void WriteData<T>(StringBuilder builder, char separator, IEnumerable<T> objectsToSerialize)
        {
            var properties = typeof(T).GetProperties();
            foreach(var obj in objectsToSerialize)
            {
                var values = new List<Object>();
                foreach(var property in properties)
                {
                    var value = property.GetValue(obj);
                    values.Add(value);
                }
                var line = String.Join(separator, values.ToArray());
                builder.AppendLine(line);
            }
        }

        private string GetDescriptionOf(PropertyInfo propertyInfo)
        {
            var descriptionAttributes = propertyInfo
                .GetCustomAttributes(typeof(DescriptionAttribute), true) as DescriptionAttribute[];

            if(descriptionAttributes.Length > 0)
            {
                return descriptionAttributes[0].Description;
            }
            return propertyInfo.Name;
        }
    }
}