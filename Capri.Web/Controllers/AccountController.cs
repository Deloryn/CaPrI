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

        private IAccountService _accountService;

        public AccountController(IAccountService userService)
        {
            _accountService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]UserCredentials credentials)
        {
            if (credentials == null)
                return BadRequest("Credentials not given");
            var userToken = await _accountService.Authenticate(credentials.Email, credentials.Password);
           
            if (userToken == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            else
            {
                return Ok(userToken);
            }
        }
    }
}