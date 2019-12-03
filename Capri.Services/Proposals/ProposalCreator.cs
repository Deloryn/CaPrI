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
        private readonly ISubmittedProposalGetter _submittedProposalGetter;

        public ProposalCreator(ISqlDbContext context, IMapper mapper, IApplicationUserGetter userGetter, ISubmittedProposalGetter submittedProposalGetter)
        {
            _context = context;
            _mapper = mapper;
            _userGetter = userGetter;
            _submittedProposalGetter = submittedProposalGetter;
        }

        public async Task<IServiceResult<Proposal>> Create(ProposalRegistration proposalRegistration)
        {
            var currentUser = await _userGetter.GetCurrentUser();
            var currentPromoter = await _context.Promoters.FirstOrDefaultAsync(p => p.UserId == currentUser.Id);

            if (proposalRegistration.Level == StudyLevel.Master)
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

            var proposal = _mapper.Map<Proposal>(proposalRegistration);
            proposal.Id = Guid.NewGuid();
            proposal.Promoter = currentPromoter;
            currentPromoter.Proposals.Add(proposal);
            _context.Promoters.Update(currentPromoter);


            await _context.Proposals.AddAsync(proposal);
            await _context.SaveChangesAsync();

            return ServiceResult<Proposal>.Success(proposal);
        }
    }
}
