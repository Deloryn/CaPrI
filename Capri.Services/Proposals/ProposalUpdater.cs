using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
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

        public ProposalUpdater(
            ISqlDbContext context, 
            IMapper mapper, 
            IUserGetter userGetter)
        {
            _context = context;
            _mapper = mapper;
            _userGetter = userGetter;
        }
        public async Task<IServiceResult<ProposalViewModel>> Update(
            Guid id, 
            ProposalRegistration inputData)
        {
            if(NumOfStudentsExceedsTheMaximum(inputData.Students, inputData.MaxNumberOfStudents))
            {
                return ServiceResult<ProposalViewModel>.Error("The number of students exceeds the maximal number");
            }

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
                    $"This promoter has no proposal with id {id}");
            }

            proposal = _mapper.Map(inputData, proposal);
            AssignProposalStatus(proposal);

            _context.Proposals.Update(proposal);
            await _context.SaveChangesAsync();

            var proposalViewModels = _mapper.Map<ProposalViewModel>(proposal);
            return ServiceResult<ProposalViewModel>.Success(proposalViewModels);
        }

        private bool NumOfStudentsExceedsTheMaximum(ICollection<Guid> students, int maxNumOfStudents)
        {
            if(students == null)
            {
                return false;
            }
            else if(students.Count() <= maxNumOfStudents)
            {
                return false;
            }
            return true;
        }

        private void AssignProposalStatus(Proposal proposal)
        {
            if(proposal.Students == null)
            {
                proposal.Status = ProposalStatus.Free;
            }
            else if(proposal.Students.Count() < proposal.MaxNumberOfStudents)
            {
                proposal.Status = ProposalStatus.PartiallyTaken;
            }
            else
            {
                proposal.Status = ProposalStatus.Taken;
            }
        }
    }
}
