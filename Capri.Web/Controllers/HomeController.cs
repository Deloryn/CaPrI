using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Capri.Web.ViewModels.Common;

namespace Capri.Web.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            _logger.LogInformation("HomeController Index");
            return View();
        }

        [Route("login")]
        public IActionResult GUILogin()
        {
            return View();
        }

        [HttpPost("login")]
        [Consumes("application/x-www-form-urlencoded")]
        public IActionResult GUILogin([FromForm] eLoginRedirection eLoginRedirection)
        {
            ViewData.Add(new KeyValuePair<string, object>("sessionKey", eLoginRedirection.SessionAuthorizationKey));
            return View();
        }
    }
}