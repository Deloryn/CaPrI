using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capri.Services.Students;

namespace Capri.Web.Controllers
{
    [Route("students")]
    public class StudentController : Controller
    {
        private readonly IStudentGetter _studentGetter;

        public StudentController(IStudentGetter studentGetter)
        {
            _studentGetter = studentGetter;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _studentGetter.Get(id);
            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _studentGetter.GetAll();
            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }
    }
}