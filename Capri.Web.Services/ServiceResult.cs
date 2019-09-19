using System;
using System.Collections.Generic;
using System.Text;
using Capri.Web.ViewModels;

namespace Capri.Web.Services
{
    public static class ServiceResult
    {
        private static readonly String _userErrorsTag = "User";

        public static IServiceResult Of(Result result)
        {
            return new ServiceResultValue
            {
                Result = result
            };
        }

        public static IServiceResult UserNotFound()
        {
            return Error(_userErrorsTag, "User not found");
        }

        public static IServiceResult UserCantSignIn()
        {
            return Error(_userErrorsTag, "User can't sign in");
        }

        private static IServiceResult Error(string tag, string description)
        {
            return new ServiceResultError
            {
                Tag = tag,
                Description = description
            };
        }
    }

    public interface IServiceResult
    {
    }

    class ServiceResultValue : IServiceResult
    {
        public Result Result { get; set; }
    }

    class ServiceResultError : IServiceResult
    {
        public String Tag { get; set; }
        public String Description { get; set; }
    }
}
