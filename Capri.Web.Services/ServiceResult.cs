using System;
using System.Collections.Generic;
using System.Text;
using Capri.Web.ViewModels;

namespace Capri.Services
{
    public class ServiceResult<T>
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public T Data { get; set; }

        private ServiceResult() { }

        public static ServiceResult<T> Success(T data)
        {
            return new ServiceResult<T>
            {
                Type = ResultType.Success,
                Data = data
            };
        }

        public static ServiceResult<T> Failure(string description)
        {
            return new ServiceResult<T>
            {
                Type = ResultType.Failure,
                Description = description
            };
        }

        public static ServiceResult<T> NotFound(string description)
        {
            return new ServiceResult<T>
            {
                Type = ResultType.NotFound,
                Description = description
            };
        }
    }
}
