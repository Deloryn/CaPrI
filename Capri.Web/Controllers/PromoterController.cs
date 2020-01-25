using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Capri.Services.Promoters;
using Capri.Web.ViewModels.Promoter;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Collections.Generic;

namespace Capri.Web.Controllers
{
    [Route("promoters")]
    public class PromoterController : Controller
    {
        private readonly IPromoterCreator _promoterCreator;
        private readonly IPromoterUpdater _promoterUpdater;
        private readonly IPromoterGetter _promoterGetter;
        private readonly IPromoterDeleter _promoterDeleter;
        private readonly IPromoterImporter _promoterImporter;

        public PromoterController(
            IPromoterCreator promoterCreator,
            IPromoterUpdater promoterUpdater,
            IPromoterGetter promoterGetter,
            IPromoterDeleter promoterDeleter,
            IPromoterImporter promoterImporter)
        {
            _promoterCreator = promoterCreator;
            _promoterUpdater = promoterUpdater;
            _promoterGetter = promoterGetter;
            _promoterDeleter = promoterDeleter;
            _promoterImporter = promoterImporter;
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

        [Authorize(Roles = "dean")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            Guid id,
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

            var result = await _promoterUpdater.Update(id, registration);
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

        [Authorize(Roles = "dean")]
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

        [Authorize(Roles = "dean")]
        [HttpPost("import")]
        public async Task<IActionResult> Import(IFormFile promotersImport)
        {
            if(promotersImport.Length > 0)
            {
                var stream = new StreamReader(promotersImport.OpenReadStream());
                var text = await stream.ReadToEndAsync();
                IEnumerable<PromoterJsonRecord> promotersList;

                try
                {
                    promotersList = JsonConvert.DeserializeObject<IEnumerable<PromoterJsonRecord>>(text);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                var result = await _promoterImporter.Import(promotersList);

                return Ok(result.Body());
            }
            return BadRequest("The file is empty.");
        }
    }
}