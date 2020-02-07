using System;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Capri.Services.Account;
using Capri.Web.ViewModels.Common;

namespace Capri.Web.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly ILoginService _loginService;

        public AccountController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] VueRedirection vueRedirection)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("The given data is not valid for this request");
            }

            var result = 
                await _loginService.Login(vueRedirection.SessionAuthorizationKey);

            if(result.Successful())
            {
                return Ok(result.Body());
            }
            
            return BadRequest(result.GetAggregatedErrors());
        }
    }
}