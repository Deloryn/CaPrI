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
    public class ProposalUpdater : IProposalUpdater
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserGetter _userGetter;

        public ProposalUpdater(ISqlDbContext context, IMapper mapper, IUserGetter userGetter)
        {
            _context = context;
            _mapper = mapper;
            _userGetter = userGetter;
        }
        public async Task<IServiceResult<Proposal>> Update(Guid id, ProposalUpdate proposalUpdate)
        {
            var currentUser = await _userGetter.GetCurrentUser();
            var currentPromoter = await _context.Promoters.FirstOrDefaultAsync(p => p.UserId == currentUser.Id);

            if (proposalUpdate.Level == StudyLevel.Master)
            {
                if (currentPromoter.CanSubmitMasterProposals == false)
                    return ServiceResult<Proposal>.Error("You do not have permissions to create master proposal.");
            }
            else
            {
                if (currentPromoter.CanSubmitBachelorProposals == false)
                    return ServiceResult<Proposal>.Error("You do not have permissions to create bachelor proposal.");
            }

            var proposal = await _context.Proposals.FirstOrDefaultAsync(p => p.Id == id);

            if (proposal == null)
            {
                return ServiceResult<Proposal>.Error("Proposal with given id does not exist.");
            }

            proposal = _mapper.Map<Proposal>(proposalUpdate);

            _context.Proposals.Update(proposal);
            await _context.SaveChangesAsync();

            return ServiceResult<Proposal>.Success(proposal);
        }
    }
}
