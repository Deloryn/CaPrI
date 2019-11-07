using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Capri.Database.Entities.Identity;
using Capri.Services;
using Capri.Web.ViewModels.Proposal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Capri.Web.Controllers
{
    [Route("proposals")]
    public class ProposalController : Controller
    {
        private readonly IProposalCreator _proposalCreator;
        private readonly IProposalDeleter _proposalDeleter;
        private readonly IProposalGetter _proposalGetter;
        private readonly IProposalUpdater _proposalUpdater;
        private readonly UserManager<User> _userManager;

        public ProposalController(
            UserManager<User> userManager,
            IProposalCreator proposalCreator,
            IProposalDeleter proposalDeleter,
            IProposalGetter proposalGetter,
            IProposalUpdater proposalUpdater)
        {
            _userManager = userManager;
            _proposalCreator = proposalCreator;
            _proposalDeleter = proposalDeleter;
            _proposalGetter = proposalGetter;
            _proposalUpdater = proposalUpdater; 
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _proposalGetter.Get(id);
            if (result.Successful())
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
            var results = _proposalGetter.GetAll();
            if (results.Successful())
            {
                return Ok(results);
            }
            else
            {
                return BadRequest(results);
            }
        }

        [Authorize(Roles = "promoter")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProposalRegistration registration)
        {
            var user = getCurrentUser();

            var result = await _proposalCreator.Create(registration, user.Result);
            if (result.Successful())
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [Authorize(Roles = "promoter")]
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ProposalUpdate update)
        {
            var user = getCurrentUser();

            var result = await _proposalUpdater.Update(id, update, user.Result);
            if (result.Successful())
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [Authorize(Roles = "promoter")]
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _proposalDeleter.Delete(id);
            if (result.Successful())
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        private Task<User> getCurrentUser()
        {
            //var sub = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return _userManager.FindByIdAsync(userId);
        }
    }
}