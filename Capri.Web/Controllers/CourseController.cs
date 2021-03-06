﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Capri.Services.Courses;

namespace Capri.Web.Controllers
{
    [Route("courses")]
    public class CourseController : Controller
    {
        private readonly ICourseGetter _courseGetter;

        public CourseController(ICourseGetter courseGetter)
        {
            _courseGetter = courseGetter;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _courseGetter.Get(id);
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
            var result = _courseGetter.GetAll();
            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }
    }
}