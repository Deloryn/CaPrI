﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Capri.Services.Institutes;

namespace Capri.Web.Controllers
{
    [Route("institutes")]
    public class InstituteController : Controller
    {
        private readonly IInstituteGetter _instituteGetter;

        public InstituteController(IInstituteGetter instituteGetter)
        {
            _instituteGetter = instituteGetter;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _instituteGetter.Get(id);
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
            var result = _instituteGetter.GetAll();
            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }
    }
}