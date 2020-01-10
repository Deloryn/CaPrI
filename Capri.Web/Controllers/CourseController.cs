using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Capri.Database.Entities.Identity;
using Capri.Services.Courses;
using Capri.Web.ViewModels.Course;

namespace Capri.Web.Controllers
{
    [Route("courses")]
    public class CourseController : Controller
    {
        private readonly ICourseCreator _courseCreator;
        private readonly ICourseUpdater _courseUpdater;
        private readonly ICourseGetter _courseGetter;
        private readonly ICourseDeleter _courseDeleter;

        public CourseController(
            ICourseCreator courseCreator,
            ICourseUpdater courseUpdater,
            ICourseGetter courseGetter,
            ICourseDeleter courseDeleter)
        {
            _courseCreator = courseCreator;
            _courseUpdater = courseUpdater;
            _courseGetter = courseGetter;
            _courseDeleter = courseDeleter;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _courseGetter.Get(id);
            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }

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

        [Authorize(Roles = RoleType.Dean)]
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CourseRegistration registration)
        {
            if(registration == null)
            {
                return BadRequest("Course registration not given");
            }

            if(!ModelState.IsValid)
            {
                return BadRequest("The given course registration is invalid");
            }

            var result = await _courseCreator.Create(registration);
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
            [FromBody] CourseRegistration registration)
        {
            if(id == null || id == Guid.Empty)
            {
                return NotFound();
            }
            
            if(registration == null)
            {
                return BadRequest("Course registration not given");
            }

            if(!ModelState.IsValid)
            {
                return BadRequest("The given course registration is invalid");
            }

            var result = await _courseUpdater.Update(id, registration);
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
            var result = await _courseDeleter.Delete(id);
            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }
    }
}