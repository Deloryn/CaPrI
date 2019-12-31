﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "dean")]
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] PromoterRegistration registration)
        {
            if(registration == null || !ModelState.IsValid)
            {
                return BadRequest("You provided invalid data");
            }

            var result = await _promoterCreator.Create(registration);
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
            [FromBody] PromoterRegistration newData)
        {
            if(newData == null || !ModelState.IsValid)
            {
                return BadRequest("You provided invalid data");
            }

            var result = await _promoterUpdater.Update(id, newData);
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
            var result = await _promoterDeleter.Delete(id);
            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }
    }
}