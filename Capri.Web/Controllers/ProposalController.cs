﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
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

        public ProposalController(
            IProposalCreator proposalCreator,
            IProposalDeleter proposalDeleter,
            IProposalGetter proposalGetter,
            IProposalUpdater proposalUpdater,
            ISubmittedProposalGetter submittedProposalGetter)
        {
            _proposalCreator = proposalCreator;
            _proposalDeleter = proposalDeleter;
            _proposalGetter = proposalGetter;
            _proposalUpdater = proposalUpdater;
            _submittedProposalGetter = submittedProposalGetter;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _proposalGetter.Get(id);
            if (result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }

        [AllowedRoles(RoleType.Dean, RoleType.Admin)]
        [HttpGet("{id}/csv")]
        public async Task<IActionResult> GetCsvFile(int id)
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

        [AllowedRoles(RoleType.Dean, RoleType.Admin)]
        [HttpGet("{id}/docx")]
        public async Task<IActionResult> GetDiplomaCardFile(int id)
        {
            var result = await _proposalGetter.GetDiplomaCard(id);
            if (result.Successful())
            {
                var fileDescription = result.Body();
                return File(fileDescription.Bytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", fileDescription.Name);
            }
            return BadRequest(result.GetAggregatedErrors());
        }

        [Authorize]
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

        [Authorize]
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

        [Authorize]
        [HttpGet("filtered/total")]
        public IActionResult Count(SieveModel sieveModel)
        {
            var result = _proposalGetter.Count(sieveModel);
            if(result.Successful())
            {
                return Ok(result.Body());
            }
            return BadRequest(result.GetAggregatedErrors());
        }

        [AllowedRoles(RoleType.Dean, RoleType.Promoter, RoleType.Admin)]
        [HttpGet("submitted/bachelor/{promoterId}")]
        public async Task<IActionResult> GetSubmittedBachelorProposals(int promoterId)
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

        [AllowedRoles(RoleType.Dean, RoleType.Promoter, RoleType.Admin)]
        [HttpGet("submitted/master/{promoterId}")]
        public async Task<IActionResult> GetSubmittedMasterProposals(int promoterId)
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
            int id, 
            [FromBody] ProposalRegistration registration)
        {   
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
        public async Task<IActionResult> Delete(int id)
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