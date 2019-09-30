using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Capri.Web.ViewModels.User;
using Capri.Services;

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
        public async Task<IActionResult> Login([FromBody]UserCredentials credentials)
        {
            if (credentials == null)
            {
                return BadRequest("Credentials not given");
            }

            var result = 
                await _loginService.Login(credentials.Email, credentials.Password);

            switch(result.Type)
            {
                case ResultType.Success:
                    return Ok(result);
                case ResultType.NotFound:
                    return NotFound(result);
                default:
                    return BadRequest(result);
            }
        }
    }
}