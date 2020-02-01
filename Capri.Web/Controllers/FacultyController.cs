using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capri.Services.Faculties;

namespace Capri.Web.Controllers
{
    [Route("faculties")]
    public class FacultyController : Controller
    {
        private readonly IFacultyGetter _facultyGetter;

        public FacultyController(IFacultyGetter facultyGetter)
        {
            _facultyGetter = facultyGetter;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _facultyGetter.Get(id);
            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _facultyGetter.GetAll();
            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }
    }
}