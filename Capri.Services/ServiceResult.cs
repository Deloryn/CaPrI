﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using Capri.Web.ViewModels;

namespace Capri.Services
{
    public class ServiceResult<T> : Dictionary<string, string>, IServiceResult<T>
    {
        private T _body;
        private bool? _successful;        
        public ServiceResult() { }        

        public ServiceResult(bool successful)
        {
            _successful = successful;
        }        

        public static ServiceResult<T> Success(T body)
        {
            ServiceResult<T> serviceResult = new ServiceResult<T>(true);
            serviceResult._body = body;
            return serviceResult;
        }

        public static ServiceResult<T> Error(params string[] errors)
        {
            ServiceResult<T> serviceResult = new ServiceResult<T>(false);
            foreach (var errorMessage in errors)
            {
                serviceResult.AddError(string.Empty, errorMessage);
            }
            return serviceResult;
        }        
        
        public static ServiceResult<T> Error(IEnumerable<string> errors)
        {
            ServiceResult<T> serviceResult = new ServiceResult<T>(false);
            foreach (var errorMessage in errors)
            {
                serviceResult.AddError(string.Empty, errorMessage);
            }
            return serviceResult;
        }        
        
        public bool Successful()
        {
            return _successful ?? IsValid();
        }        
        
        public bool IsValid()
        {
            return !this.Any();
        }        
        
        public IEnumerable<string> GetAggregatedErrors()
        {
            return this.Values.ToList();
        }

        public T Body()
        {
            return this._body;
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