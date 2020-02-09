using System.Linq;
using System;
using System.Collections.Generic;
using PUT.WebServices.eDziekanatServiceClient;
using PUT.WebServices.eDziekanatServiceClient.eDziekanatService;

namespace Capri.Services.Students
{
    public class StudentGetter : IStudentGetter
    {
        private readonly IEDziekanatClient _eDziekanatClient;
        
        public StudentGetter(
            IEDziekanatClient eDziekanatClient
        )
        {
            _eDziekanatClient = eDziekanatClient;
        }

        public IServiceResult<BasicStudentData[]> GetMany(string indexNumbersString)
        {
            var indexNumbers = indexNumbersString
                .Split(",")
                .Select(str => Int32.Parse(str))
                .ToList();
            
            return GetMany(indexNumbers);
        }

        public IServiceResult<BasicStudentData[]> GetMany(ICollection<int> indexNumbers)
        {
            try
            {
                var result = _eDziekanatClient.GetAllStudentsByIds(indexNumbers.ToArray());
                return ServiceResult<BasicStudentData[]>.Success(result);
            }
            catch
            {
                return ServiceResult<BasicStudentData[]>.Error(
                    $"Failed to obtain data of the students with the given ids"
                );
            }
        }
    }
}