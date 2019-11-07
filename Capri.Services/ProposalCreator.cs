using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Capri.Database;
using Capri.Database.Entities;
using Capri.Database.Entities.Identity;
using Capri.Web.ViewModels.Proposal;
using Microsoft.EntityFrameworkCore;

namespace Capri.Services
{
    public class ProposalCreator : IProposalCreator
    {
        private readonly ISqlDbContext _context;

        public ProposalCreator(ISqlDbContext context)
        {
            _context = context;
        }

        public async Task<IServiceResult<Proposal>> Create(ProposalRegistration proposalRegistration, User user)
        {
            var currentPromoter = await _context.Promoters.FirstOrDefaultAsync(p => p.UserId == user.Id);
            if (currentPromoter.CanSubmitBachelorProposals == false && currentPromoter.CanSubmitMasterProposals == false)
            {
                return ServiceResult<Proposal>.Error("You do not have permissions to create proposal.");
            }
            if (currentPromoter.CanSubmitBachelorProposals == false && proposalRegistration.Type == ProposalType.Bachelor)
            {
                return ServiceResult<Proposal>.Error("You do not have permissions to create bachelor proposal.");
            }
            if (currentPromoter.CanSubmitMasterProposals == false && proposalRegistration.Type == ProposalType.Master)
            {
                return ServiceResult<Proposal>.Error("You do not have permissions to create master proposal.");
            }

            var proposal = new Proposal
            {
                Id = Guid.NewGuid(),
                Topic = proposalRegistration.Topic,
                Description = proposalRegistration.Description,
                Status = proposalRegistration.Status,
                Type = proposalRegistration.Type
            };

            await _context.Proposals.AddAsync(proposal);
            await _context.SaveChangesAsync();

            return ServiceResult<Proposal>.Success(proposal);
        }
    }
}
