using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Capri.Database;
using Capri.Database.Entities;
using Capri.Database.Entities.Identity;
using Capri.Web.ViewModels.Proposal;
using Microsoft.EntityFrameworkCore;

namespace Capri.Services.Proposals
{
    public class ProposalCreator : IProposalCreator
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
        private readonly IApplicationUserGetter _userGetter;

        public ProposalCreator(ISqlDbContext context, IMapper mapper, IApplicationUserGetter userGetter)
        {
            _context = context;
            _mapper = mapper;
            _userGetter = userGetter;
        }

        public async Task<IServiceResult<Proposal>> Create(ProposalRegistration proposalRegistration)
        {
            var currentUser = await _userGetter.GetCurrentUser();
            var currentPromoter = await _context.Promoters.FirstOrDefaultAsync(p => p.UserId == currentUser.Id);

            if (proposalRegistration.Type == ProposalType.Master)
            {
                if (currentPromoter.CanSubmitMasterProposals == false)
                    return ServiceResult<Proposal>.Error("You do not have permissions to create master proposal.");
            }
            else
            {
                if (currentPromoter.CanSubmitBachelorProposals == false)
                    return ServiceResult<Proposal>.Error("You do not have permissions to create bachelor proposal.");
            }

            var proposal = _mapper.Map<Proposal>(proposalRegistration);
            proposal.Id = Guid.NewGuid();

            await _context.Proposals.AddAsync(proposal);
            await _context.SaveChangesAsync();

            return ServiceResult<Proposal>.Success(proposal);
        }
    }
}
