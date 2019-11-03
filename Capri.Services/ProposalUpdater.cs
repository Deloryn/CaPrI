using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Capri.Database;
using Capri.Database.Entities;
using Capri.Web.ViewModels.Proposal;

namespace Capri.Services
{
    public class ProposalUpdater : IProposalUpdater
    {
        private readonly ISqlDbContext _context;

        public ProposalUpdater(ISqlDbContext context)
        {
            _context = context;
        }
        public async Task<IServiceResult<Proposal>> Update(Guid id, ProposalUpdate proposalUpdate)
        {
            var proposal = await _context.Proposals.FirstOrDefaultAsync(p => p.Id == id);

            if (proposal == null)
            {
                return ServiceResult<Proposal>.Error("Proposal with given id does not exist.");
            }

            proposal.Topic = proposalUpdate.Topic;
            proposal.Description = proposalUpdate.Description;
            proposal.Status = proposalUpdate.Status;
            proposal.Type = proposalUpdate.Type;

            _context.Proposals.Update(proposal);
            await _context.SaveChangesAsync();

            throw new NotImplementedException();
        }
    }
}
