using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Capri.Services;
using Capri.Web.ViewModels.Promoter;

namespace Capri.Web.Controllers
{
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

        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _promoterGetter.Get(id);
            if(result.Successful())
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _promoterGetter.GetAll();
            if(result.Successful())
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [Authorize(Roles = "dean")]
        [HttpPost]
        public IActionResult Create([FromBody] PromoterRegistration registration)
        {
            var result = _promoterCreator.Create(registration);
            if(result.Successful())
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [Authorize(Roles = "dean")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PromoterUpdate newData)
        {
            var result = await _promoterUpdater.Update(newData);
            if(result.Successful())
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [Authorize(Roles = "dean")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _promoterDeleter.Delete(id);
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