using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Capri.Services;

namespace Capri.Web.Controllers
{
    [Route("settings")]
    public class SettingsController : Controller
    {
        private readonly ISettingsService _settingsService;

        public SettingsController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        [HttpGet("bachelor/max-per-promoter")]
        public IActionResult GetMaxNumOfBachelorProposalsPerPromoter()
        {
            var result = _settingsService.GetMaxNumOfBachelorProposalsPerPromoter();
            if(result.Successful())
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("master/max-per-promoter")]
        public IActionResult GetMaxNumOfMasterProposalsPerPromoter()
        {
            var result = _settingsService.GetMaxNumOfMasterProposalsPerPromoter();
            if(result.Successful())
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPut("bachelor/max-per-promoter/{number:int}")]
        public IActionResult SetMaxNumOfBachelorProposalsPerPromoter(int number)
        {
            var result = _settingsService.SetMaxNumOfBachelorProposalsPerPromoter(number);
            if(result.Successful())
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPut("master/max-per-promoter/{number:int}")]
        public IActionResult SetMaxNumOfMasterProposalsPerPromoter(int number)
        {
            var result = _settingsService.SetMaxNumOfMasterProposalsPerPromoter(number);
            if(result.Successful())
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}