using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Capri.Web.DTO;
using Capri.Web.Services;

namespace Capri.Web.Controllers
{
    public class UsersController : Controller
    {

        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]UserCredentialsDTO credentials)
        {
            if (credentials == null)
                return BadRequest("Credentials not given");
            var userToken = _userService.Authenticate(credentials.Email, credentials.Password);

            if (userToken == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(userToken);
        }
    }
}