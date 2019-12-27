﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Capri.Database;
using Capri.Services.Promoters;
using Capri.Services.Users;
using Capri.Web.ViewModels.Proposal;

namespace Capri.Services.Proposals
{
    public class ProposalDeleter : IProposalDeleter
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPromoterGetter _promoterGetter;
        private readonly IUserGetter _userGetter;

        public ProposalDeleter(
            ISqlDbContext context, 
            IMapper mapper,
            IPromoterGetter promoterGetter,
            IUserGetter userGetter)
        {
            _context = context;
            _mapper = mapper;
            _promoterGetter = promoterGetter;
            _userGetter = userGetter;
        }

        public async Task<IServiceResult<ProposalViewModel>> Delete(Guid id)
        {
            var result = await _userGetter.GetCurrentUser();
            if(!result.Successful())
            {
                var errors = result.GetAggregatedErrors();
                return ServiceResult<ProposalViewModel>.Error(errors);
            }
            
            var currentUser = result.Body();
            var promoter = 
                await _context
                .Promoters
                .Include(p => p.Proposals)
                .FirstOrDefaultAsync(p => p.UserId == currentUser.Id);

            if(promoter == null)
            {
                return ServiceResult<ProposalViewModel>.Error("The current user has no associated promoter");
            }
            
            var proposal = promoter.Proposals.FirstOrDefault(p => p.Id == id);

            if (proposal == null)
            {
                return ServiceResult<ProposalViewModel>.Error(
                    $"Promoter with id {promoter.Id} has no proposal with id {id}");
            }

            _context.Proposals.Remove(proposal);
            await _context.SaveChangesAsync();

            var proposalViewModel = _mapper.Map<ProposalViewModel>(proposal);
            return ServiceResult<ProposalViewModel>.Success(proposalViewModel);
        }
    }
}
