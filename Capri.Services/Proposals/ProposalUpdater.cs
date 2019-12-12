using System;
using System.Linq;
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
        private readonly ISubmittedProposalGetter _submittedProposalGetter;

        public ProposalUpdater(ISqlDbContext context, IMapper mapper, IUserGetter userGetter, ISubmittedProposalGetter submittedProposalGetter)
        {
            _context = context;
            _mapper = mapper;
            _userGetter = userGetter;
            _submittedProposalGetter = submittedProposalGetter;
        }
        public async Task<IServiceResult<Proposal>> Update(Guid id, ProposalUpdate inputData)
        {
            var result = await _userGetter.GetCurrentUser();
            if(!result.Successful())
            {
                var errors = result.GetAggregatedErrors();
                return ServiceResult<Proposal>.Error(errors);
            }
            
            var currentUser = result.Body();
            var promoter = 
                await _context
                .Promoters
                .FirstOrDefaultAsync(p => p.UserId == currentUser.Id);

            if(promoter == null)
            {
                return ServiceResult<Proposal>.Error("The current user has no associated promoter");
            }
            
            var proposal = promoter.Proposals.FirstOrDefault(p => p.Id == id);

            if (proposal == null)
            {
                return ServiceResult<Proposal>.Error("This promoter has no proposal with the given id.");
            }

            proposal = _mapper.Map<Proposal>(inputData);

            _context.Proposals.Update(proposal);
            await _context.SaveChangesAsync();

            return ServiceResult<Proposal>.Success(proposal);
        }
    }
}
