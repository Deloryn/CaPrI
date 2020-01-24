using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Sieve.Models;
using Capri.Database.Entities;
using Capri.Database.Entities.Identity;
using Capri.Services.Proposals;
using Capri.Web.Controllers.Attributes;
using Capri.Web.ViewModels.Proposal;

namespace Capri.Web.Controllers
{
    [Route("proposals")]
    public class ProposalController : Controller
    {
        private readonly IProposalCreator _proposalCreator;
        private readonly IProposalDeleter _proposalDeleter;
        private readonly IProposalGetter _proposalGetter;
        private readonly IProposalUpdater _proposalUpdater;
        private readonly ISubmittedProposalGetter _submittedProposalGetter;
        private readonly UserManager<User> _userManager;

        public ProposalController(
            IProposalCreator proposalCreator,
            IProposalDeleter proposalDeleter,
            IProposalGetter proposalGetter,
            IProposalUpdater proposalUpdater,
            ISubmittedProposalGetter submittedProposalGetter,
            UserManager<User> userManager)
        {
            _proposalCreator = proposalCreator;
            _proposalDeleter = proposalDeleter;
            _proposalGetter = proposalGetter;
            _proposalUpdater = proposalUpdater;
            _submittedProposalGetter = submittedProposalGetter;
            _userManager = userManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _proposalGetter.Get(id);
            if (result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }

        [AllowedRoles(RoleType.Dean)]
        [HttpGet("{id}/csv")]
        public async Task<IActionResult> GetCsvFile(Guid id)
        {
            var result = await _proposalGetter.GetCsvFileDescription(id);
            if(result.Successful())
            {
                var fileDescription = result.Body();
                return File(fileDescription.Bytes, "text/csv", fileDescription.Name);
            }
            return BadRequest(result.GetAggregatedErrors());
        }

        [AllowedRoles(RoleType.Promoter)]
        [HttpGet("mine")]
        public async Task<IActionResult> GetMyProposals() 
        {
            var result = await _proposalGetter.GetMyProposals();
            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _proposalGetter.GetAll();
            if (result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }

        [HttpGet("filtered")]
        public IActionResult GetFiltered(SieveModel sieveModel)
        {
            var result = _proposalGetter.GetFiltered(sieveModel);
            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }

        [AllowedRoles(RoleType.Dean, RoleType.Promoter)]
        [HttpGet("submitted/bachelor/{promoterId}")]
        public async Task<IActionResult> GetSubmittedBachelorProposals(Guid promoterId)
        {
            var result = 
                await _submittedProposalGetter
                .CountSubmittedProposals(promoterId, StudyLevel.Bachelor);

            if (result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }

        [AllowedRoles(RoleType.Dean, RoleType.Promoter)]
        [HttpGet("submitted/master/{promoterId}")]
        public async Task<IActionResult> GetSubmittedMasterProposals(Guid promoterId)
        {
            var result = 
                await _submittedProposalGetter
                .CountSubmittedProposals(promoterId, StudyLevel.Master);

            if (result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }

        [AllowedRoles(RoleType.Promoter)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProposalRegistration registration)
        {
            if(registration == null)
            {
                return BadRequest("Proposal registration not given");
            }

            if(!ModelState.IsValid)
            {
                return BadRequest("The given proposal registration is invalid");
            }

            var result = await _proposalCreator.Create(registration);
            if (result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }

        [AllowedRoles(RoleType.Promoter)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            Guid id, 
            [FromBody] ProposalRegistration registration)
        {
            if(id == Guid.Empty)
            {
                return NotFound();
            }
            
            if(registration == null)
            {
                return BadRequest("Proposal registration not given");
            }

            if(!ModelState.IsValid)
            {
                return BadRequest("The given proposal registration is invalid");
            }

            var result = await _proposalUpdater.Update(id, registration);
            if (result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }

        [AllowedRoles(RoleType.Promoter)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _proposalDeleter.Delete(id);
            if (result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }

    }
}