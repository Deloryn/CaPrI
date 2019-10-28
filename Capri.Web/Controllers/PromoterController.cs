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
        private readonly IPromoterService _promoterService;

        public PromoterController(IPromoterService promoterService)
        {
            _promoterService = promoterService;
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            var result = _promoterService.Get(id);
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
            var result = _promoterService.GetAll();
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
            var result = _promoterService.Create(registration);
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
        public IActionResult Update([FromBody] PromoterUpdate newData)
        {
            var result = _promoterService.Update(newData);
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
        public IActionResult Delete(Guid id)
        {
            var result = _promoterService.Delete(id);
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