using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Capri.Database.Entities.Identity;
using Capri.Services.Promoters;
using Capri.Web.ViewModels.Promoter;

namespace Capri.Web.Controllers
{
    [Route("promoters")]
    public class PromoterController : Controller
    {
        private readonly IPromoterCreator _promoterCreator;
        private readonly IPromoterUpdater _promoterUpdater;
        private readonly IPromoterGetter _promoterGetter;
        private readonly IPromoterDeleter _promoterDeleter;

        public PromoterController(
            IPromoterCreator promoterCreator,
            IPromoterUpdater promoterUpdater,
            IPromoterGetter promoterGetter,
            IPromoterDeleter promoterDeleter)
        {
            _promoterCreator = promoterCreator;
            _promoterUpdater = promoterUpdater;
            _promoterGetter = promoterGetter;
            _promoterDeleter = promoterDeleter;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _promoterGetter.Get(id);
            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _promoterGetter.GetAll();
            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }

        [Authorize(Roles = RoleType.Dean)]
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] PromoterRegistration registration)
        {
            if(registration == null)
            {
                return BadRequest("Promoter registration not given");
            }

            if(!ModelState.IsValid)
            {
                return BadRequest("The given promoter registration is invalid");
            }

            var result = await _promoterCreator.Create(registration);
            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }

        [Authorize(Roles = RoleType.Dean)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            Guid id,
            [FromBody] PromoterRegistration registration)
        {
            if(id == Guid.Empty)
            {
                return NotFound();
            }

            if(registration == null)
            {
                return BadRequest("Promoter registration not given");
            }

            if(!ModelState.IsValid)
            {
                return BadRequest("The given promoter registration is invalid");
            }

            var result = await _promoterUpdater.Update(id, registration);
            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }

        [Authorize(Roles = RoleType.Dean)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _promoterDeleter.Delete(id);
            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }
    }
}