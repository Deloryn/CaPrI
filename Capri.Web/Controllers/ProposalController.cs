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
    [Route("proposal")]
    public class ProposalController : Controller
    {
        private readonly IProposalCreator _proposalCreator;
        private readonly IProposalDeleter _proposalDeleter;
        private readonly IProposalGetter _proposalGetter;
        private readonly IProposalUpdater _proposalUpdater;

        public ProposalController(
            IProposalCreator proposalCreator,
            IProposalDeleter proposalDeleter,
            IProposalGetter proposalGetter,
            IProposalUpdater proposalUpdater)
        {
            _proposalCreator = proposalCreator;
            _proposalDeleter = proposalDeleter;
            _proposalGetter = proposalGetter;
            _proposalUpdater = proposalUpdater; 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _proposalGetter.Get(id);
            if (result.Successful())
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var results = _proposalGetter.GetAll();
            if (results.Successful())
            {
                return Ok(results);
            }
            return BadRequest(results);
        }

        [Authorize(Roles = "promoter")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProposalRegistration registration)
        {
            var result = await _proposalCreator.Create(registration);
            if (result.Successful())
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "promoter")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ProposalUpdate update)
        {
            var result = await _proposalUpdater.Update(id, update);
            if (result.Successful())
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "promoter")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _proposalDeleter.Delete(id);
            if (result.Successful())
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}