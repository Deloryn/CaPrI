using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Capri.Services.SystemSettings;

namespace Capri.Web.Controllers
{
    [Route("systemsettings")]
    public class SystemSettingsController : Controller
    {
        private readonly ISystemSettingsGetter _systemSettingsGetter;
        private readonly ISystemSettingsSetter _systemSettingsSetter;

        public SystemSettingsController(
            ISystemSettingsGetter systemSettingsGetter,
            ISystemSettingsSetter systemSettingsSetter)
        {
            _systemSettingsGetter = systemSettingsGetter;
            _systemSettingsSetter = systemSettingsSetter;
        }

        [Authorize(Roles = "admin,dean")]
        [HttpGet("bachelor/max-per-promoter")]
        public IActionResult GetMaxNumOfBachelorProposalsPerPromoter()
        {
            var result = _systemSettingsGetter.GetMaxNumOfBachelorProposalsPerPromoter();
            if(result.Successful())
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "admin,dean")]
        [HttpGet("master/max-per-promoter")]
        public IActionResult GetMaxNumOfMasterProposalsPerPromoter()
        {
            var result = _systemSettingsGetter.GetMaxNumOfMasterProposalsPerPromoter();
            if(result.Successful())
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("bachelor/max-per-promoter/{number}")]
        public IActionResult SetMaxNumOfBachelorProposalsPerPromoter(int number)
        {
            var result = _systemSettingsSetter.SetMaxNumOfBachelorProposalsPerPromoter(number);
            if(result.Successful())
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("master/max-per-promoter/{number}")]
        public IActionResult SetMaxNumOfMasterProposalsPerPromoter(int number)
        {
            var result = _systemSettingsSetter.SetMaxNumOfMasterProposalsPerPromoter(number);
            if(result.Successful())
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}