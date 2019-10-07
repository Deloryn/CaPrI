using System;
using System.Collections.Generic;
using System.Text;
using Capri.Web.ViewModels;

namespace Capri.Services
{
    public class ServiceResult<T> : Dictionary<string, string>
    {
        public T TBody { get; private set; }
        public bool IsSucceded { get; private set; }

        private ServiceResult() { }

        public static ServiceResult<T> Success(T body)
        {
            return new ServiceResult<T>
            {
                TBody = body,
                IsSucceded = true
            };
        }

        public static ServiceResult<T> Error(params string[] errors)
        {
            ServiceResult<T> serviceResult = new ServiceResult<T>();
            serviceResult.IsSucceded = false;
            foreach(var errorMessage in errors)
            {
                serviceResult.AddError("error", errorMessage);
            }
            return serviceResult;
        }

        private void AddError(string key, Exception exception)
        {
            this.AddError(key, exception.Message);
        }

        private void AddError(string key, string errorMessage)
        {
            this.Add(key, errorMessage);
        }
    }
}
