using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Capri.Database;
using Capri.Database.Entities;
using Capri.Web.ViewModels.Proposal;

namespace Capri.Services
{
    public class ProposalCreator : IProposalCreator
    {
        private readonly ISqlDbContext _context;

        public ProposalCreator(ISqlDbContext context)
        {
            _context = context;
        }

        public async Task<IServiceResult<Proposal>> Create(ProposalRegistration proposalRegistration)
        {
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
