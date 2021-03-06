﻿using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Sieve.Models;
using Capri.Database.Entities.Identity;
using Capri.Services.Promoters;
using Capri.Web.Controllers.Attributes;
using Capri.Web.ViewModels.Promoter;

namespace Capri.Web.Controllers
{
    [Route("promoters")]
    public class PromoterController : Controller
    {
        private readonly IPromoterUpdater _promoterUpdater;
        private readonly IPromoterGetter _promoterGetter;
        private readonly IPromoterImporter _promoterImporter;

        public PromoterController(
            IPromoterUpdater promoterUpdater,
            IPromoterGetter promoterGetter,
            IPromoterImporter promoterImporter)
        {
            _promoterUpdater = promoterUpdater;
            _promoterGetter = promoterGetter;
            _promoterImporter = promoterImporter;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _promoterGetter.Get(id);
            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }

        [Authorize]
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

        [Authorize]
        [HttpGet("filtered")]
        public IActionResult GetFiltered(SieveModel sieveModel)
        {
            var result = _promoterGetter.GetFiltered(sieveModel);
            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }

        [Authorize]
        [HttpGet("filtered/total")]
        public IActionResult Count(SieveModel sieveModel)
        {
            var result = _promoterGetter.Count(sieveModel);
            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }

        [AllowedRoles(RoleType.Promoter)]
        [HttpGet("mine")]
        public async Task<IActionResult> GetMyData()
        {
            var result = await _promoterGetter.GetMyData();
            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }

        [AllowedRoles(RoleType.Dean, RoleType.Admin)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] PromoterUpdate update)
        {
            if(update == null)
            {
                return BadRequest("Promoter registration not given");
            }

            if(!ModelState.IsValid)
            {
                return BadRequest("The given promoter registration is invalid");
            }

            var result = await _promoterUpdater.Update(id, update);
            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }

        [AllowedRoles(RoleType.Dean, RoleType.Admin)]
        [HttpGet("export")]
        public IActionResult Export()
        {
            var result = _promoterGetter.GetAllWithJsonFormat();
            if (result.Successful())
            {
                var fileDescription = result.Body();
                return File(fileDescription.Bytes, "application/json", fileDescription.Name);
            }
            return BadRequest(result.GetAggregatedErrors());
        }

        [AllowedRoles(RoleType.Dean, RoleType.Admin)]
        [HttpPost("import")]
        public async Task<IActionResult> Import(IFormFile promotersImport)
        {
            if (promotersImport != null && promotersImport.Length > 0)
            {
                var stream = new StreamReader(promotersImport.OpenReadStream());
                var text = await stream.ReadToEndAsync();
                IEnumerable<PromoterJsonRecord> promotersList;

                try
                {
                    promotersList = JsonConvert.DeserializeObject<IEnumerable<PromoterJsonRecord>>(text);
                }
                catch
                {
                    return BadRequest("Wrong JSON format");
                }

                var result = await _promoterImporter.Import(promotersList);

                return Ok(result.Body());
            }
            return BadRequest("The file is empty.");
        }
    }
}