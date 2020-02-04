using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Capri.Services.Account;
using Capri.Web.ViewModels.Common;

namespace Capri.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginService _loginService;

        public AccountController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> Login([FromForm] eLoginRedirection eLoginRedirection)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("The given data is not valid for this request");
            }

            var result = 
                await _loginService.Login(eLoginRedirection.SessionAuthorizationKey);

            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }
    }
}