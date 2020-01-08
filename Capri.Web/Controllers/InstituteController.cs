using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Capri.Services.Institutes;
using Capri.Web.ViewModels.Institute;

namespace Capri.Web.Controllers
{
    [Route("institutes")]
    public class InstituteController : Controller
    {
        private readonly IInstituteCreator _instituteCreator;
        private readonly IInstituteUpdater _instituteUpdater;
        private readonly IInstituteGetter _instituteGetter;
        private readonly IInstituteDeleter _instituteDeleter;

        public InstituteController(
            IInstituteCreator instituteCreator,
            IInstituteUpdater instituteUpdater,
            IInstituteGetter instituteGetter,
            IInstituteDeleter instituteDeleter)
        {
            _instituteCreator = instituteCreator;
            _instituteUpdater = instituteUpdater;
            _instituteGetter = instituteGetter;
            _instituteDeleter = instituteDeleter;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _instituteGetter.Get(id);
            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _instituteGetter.GetAll();
            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }

        [Authorize(Roles = "dean")]
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] InstituteRegistration registration)
        {
            if(registration == null)
            {
                return BadRequest("Institute registration not given");
            }

            if(!ModelState.IsValid)
            {
                return BadRequest("The given institute registration is invalid");
            }

            var result = await _instituteCreator.Create(registration);
            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }

        [Authorize(Roles = "dean")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            Guid id,
            [FromBody] InstituteRegistration registration)
        {
            if(id == null || id == Guid.Empty)
            {
                return NotFound();
            }

            if(registration == null)
            {
                return BadRequest("Institute registration not given");
            }

            if(!ModelState.IsValid)
            {
                return BadRequest("The given institute registration is invalid");
            }
            
            var result = await _instituteUpdater.Update(id, registration);
            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }

        [Authorize(Roles = "dean")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _instituteDeleter.Delete(id);
            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }
    }
}