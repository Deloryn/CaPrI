using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Capri.Database;
using Capri.Database.Entities;
using Capri.Services.Users;
using Capri.Web.ViewModels.Proposal;

namespace Capri.Services.Proposals
{
    public class ProposalCreator : IProposalCreator
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserGetter _userGetter;

        public ProposalCreator(ISqlDbContext context, IMapper mapper, IUserGetter userGetter)
        {
            _context = context;
            _mapper = mapper;
            _userGetter = userGetter;
        }

        public async Task<IServiceResult<Proposal>> Create(ProposalRegistration proposalRegistration)
        {
            var currentUser = await _userGetter.GetCurrentUser();
            var currentPromoter = await _context.Promoters.FirstOrDefaultAsync(p => p.UserId == currentUser.Id);

            if (proposalRegistration.Level == StudyLevel.Master)
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
