using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Capri.Web.ViewModels.User;
using Capri.Web.Services;

namespace Capri.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]UserCredentials credentials)
        {
            if (credentials == null)
                return BadRequest("Credentials not given");
            var userSecurityStamp = await _accountService.Authenticate(credentials.Email, credentials.Password);
           
            if (userSecurityStamp == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            else
            {
                return Ok(userSecurityStamp);
            }
        }
    }
}