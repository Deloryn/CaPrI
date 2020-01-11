using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Capri.Database.Entities.Identity;
using Capri.Services.Students;
using Capri.Web.ViewModels.Student;

namespace Capri.Web.Controllers
{
    [Route("students")]
    public class StudentController : Controller
    {
        private readonly IStudentCreator _studentCreator;
        private readonly IStudentUpdater _studentUpdater;
        private readonly IStudentGetter _studentGetter;
        private readonly IStudentDeleter _studentDeleter;

        public StudentController(
            IStudentCreator studentCreator,
            IStudentUpdater studentUpdater,
            IStudentGetter studentGetter,
            IStudentDeleter studentDeleter)
        {
            _studentCreator = studentCreator;
            _studentUpdater = studentUpdater;
            _studentGetter = studentGetter;
            _studentDeleter = studentDeleter;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
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

        [Authorize(Roles = RoleType.Dean)]
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] StudentRegistration registration)
        {
            if(registration == null)
            {
                return BadRequest("Student registration not given");
            }

            if(!ModelState.IsValid)
            {
                return BadRequest("The given student registration is invalid");
            }

            var result = await _studentCreator.Create(registration);
            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }

        [Authorize(Roles = RoleType.Dean)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            Guid id,
            [FromBody] StudentRegistration registration)
        {
            if(id == Guid.Empty)
            {
                return NotFound();
            }
            
            if(registration == null)
            {
                return BadRequest("Student registration not given");
            }

            if(!ModelState.IsValid)
            {
                return BadRequest("The given student registration is invalid");
            }
            
            var result = await _studentUpdater.Update(id, registration);
            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }

        [Authorize(Roles = RoleType.Dean)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _studentDeleter.Delete(id);
            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }
    }
}