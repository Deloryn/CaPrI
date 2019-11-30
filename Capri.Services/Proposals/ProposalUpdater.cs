using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Capri.Database;
using Capri.Database.Entities;
using Capri.Web.ViewModels.Proposal;
using Capri.Database.Entities.Identity;
using AutoMapper;

namespace Capri.Services.Proposals
{
    public class ProposalUpdater : IProposalUpdater
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
        private readonly IApplicationUserGetter _userGetter;
        private readonly ISubmittedProposalGetter _submittedProposalGetter;

        public ProposalUpdater(ISqlDbContext context, IMapper mapper, IApplicationUserGetter userGetter, ISubmittedProposalGetter submittedProposalGetter)
        {
            _context = context;
            _mapper = mapper;
            _userGetter = userGetter;
            _submittedProposalGetter = submittedProposalGetter;
        }
        public async Task<IServiceResult<Proposal>> Update(Guid id, ProposalUpdate proposalUpdate)
        {
            var currentUser = await _userGetter.GetCurrentUser();
            var currentPromoter = await _context.Promoters.FirstOrDefaultAsync(p => p.UserId == currentUser.Id);

            if (proposalUpdate.Level == StudyLevel.Master)
            {
                if (_submittedProposalGetter.GetMasterProposalNumber(currentPromoter.Id).Result.Body() >=
                    currentPromoter.ExpectedNumberOfMasterProposals)
                    return ServiceResult<Proposal>.Error("You do not have permissions to create master proposal.");
            }
            else
            {
                if (_submittedProposalGetter.GetBachelorProposalNumber(currentPromoter.Id).Result.Body() >=
                    currentPromoter.ExpectedNumberOfBachelorProposals)
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
