using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Capri.Services.Account;
using Capri.Web.ViewModels.Common;
using Capri.Web.ViewModels.User;

namespace Capri.Web.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly ILogoutService _logoutService;

        public AccountController(
            ILoginService loginService,
            ILogoutService logoutService
        )
        {
            _loginService = loginService;
            _logoutService = logoutService;
        }

        [AllowAnonymous]
        [HttpPost("login/direct")]
        public async Task<IActionResult> Login([FromBody] UserCredentials userCredentials)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("The given data is not valid for this request");
            }

            var result = 
                await _loginService.Login(userCredentials.Email, userCredentials.Password);

            if(result.Successful())
            {
                return Ok(result.Body());
            }
            
            return BadRequest(result.GetAggregatedErrors());
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

        [Authorize]
        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await _logoutService.Logout();
            return Ok();
        }
    }
}