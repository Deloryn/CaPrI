﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Capri.Database;
using Capri.Services.Users;
using Capri.Services.Courses;
using Capri.Web.ViewModels.Proposal;

namespace Capri.Services.Proposals
{
    public class ProposalUpdater : IProposalUpdater
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserGetter _userGetter;
        private readonly ICourseGetter _courseGetter;
        private readonly IProposalInformer _proposalInformer;

        public ProposalUpdater(
            ISqlDbContext context, 
            IMapper mapper, 
            IUserGetter userGetter,
            ICourseGetter courseGetter,
            IProposalInformer proposalInformer)
        {
            _context = context;
            _mapper = mapper;
            _userGetter = userGetter;
            _courseGetter = courseGetter;
            _proposalInformer = proposalInformer;
        }
        
        public async Task<IServiceResult<ProposalViewModel>> Update(
            Guid id, 
            ProposalRegistration inputData)
        {
            var courseResult = await _courseGetter.Get(inputData.CourseId);
            if(!courseResult.Successful())
            {
                return ServiceResult<ProposalViewModel>.Error(courseResult.GetAggregatedErrors());
            }

            var numOfStudentsExceedsTheMaximumResult = _proposalInformer
                .NumOfStudentsExceedsTheMaximum(inputData.Students, inputData.MaxNumberOfStudents);
            if(!numOfStudentsExceedsTheMaximumResult.Successful())
            {
                return ServiceResult<ProposalViewModel>.Error(numOfStudentsExceedsTheMaximumResult.GetAggregatedErrors());
            }

            var numOfStudentsExceedsTheMaximum = numOfStudentsExceedsTheMaximumResult.Body();
            if(numOfStudentsExceedsTheMaximum)
            {
                return ServiceResult<ProposalViewModel>.Error("The number of students exceeds the maximal number");
            }

            var userResult = await _userGetter.GetCurrentUser();
            if(!userResult.Successful())
            {
                var errors = userResult.GetAggregatedErrors();
                return ServiceResult<ProposalViewModel>.Error(errors);
            }
            
            var currentUser = userResult.Body();
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
                    $"This promoter has no proposal with id {id}");
            }

            proposal = _mapper.Map(inputData, proposal);

            var proposalStatusResult = _proposalInformer.CalculateProposalStatus(proposal);
            if(!proposalStatusResult.Successful())
            {
                return ServiceResult<ProposalViewModel>.Error(proposalStatusResult.GetAggregatedErrors());
            }

            var proposalStatus = proposalStatusResult.Body();
            proposal.Status = proposalStatus;

            _context.Proposals.Update(proposal);
            await _context.SaveChangesAsync();

            var proposalViewModels = _mapper.Map<ProposalViewModel>(proposal);
            return ServiceResult<ProposalViewModel>.Success(proposalViewModels);
        }
    }
}
