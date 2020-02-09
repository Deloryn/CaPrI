using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
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

        [Authorize]
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