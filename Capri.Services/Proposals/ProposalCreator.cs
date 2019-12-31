using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Capri.Database;
using Capri.Database.Entities;
using Capri.Services.Users;
using Capri.Services.Settings;
using Capri.Web.ViewModels.Proposal;

namespace Capri.Services.Proposals
{
    public class ProposalCreator : IProposalCreator
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserGetter _userGetter;
        private readonly ISubmittedProposalGetter _submittedProposalGetter;
        private readonly ISystemSettingsGetter _systemSettingsGetter;

        public ProposalCreator(
            ISqlDbContext context, 
            IMapper mapper, 
            IUserGetter userGetter, 
            ISubmittedProposalGetter submittedProposalGetter,
            ISystemSettingsGetter systemSettingsGetter)
        {
            _context = context;
            _mapper = mapper;
            _userGetter = userGetter;
            _submittedProposalGetter = submittedProposalGetter;
            _systemSettingsGetter = systemSettingsGetter;
        }

        public async Task<IServiceResult<ProposalViewModel>> Create(
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

            if(!HasPermissionToCreateProposal(promoter, inputData.Level))
            {
                return ServiceResult<ProposalViewModel>.Error("You are not allowed to create this type of proposal");
            }

            var proposal = _mapper.Map<Proposal>(inputData);

            AssignProposalStatus(proposal);
            SetStartDate(proposal);

            proposal.Promoter = promoter;
            promoter.Proposals.Add(proposal);
            _context.Promoters.Update(promoter);

            await _context.Proposals.AddAsync(proposal);
            await _context.SaveChangesAsync();

            var proposalViewModel = _mapper.Map<ProposalViewModel>(proposal);

            return ServiceResult<ProposalViewModel>.Success(proposalViewModel);
        }

        private bool HasPermissionToCreateProposal(Promoter promoter, StudyLevel level)
        {
            switch(level)
            {
                case StudyLevel.Bachelor:
                    return HasPermissionToCreateBachelorProposal(promoter);
                case StudyLevel.Master:
                    return HasPermissionToCreateMasterProposal(promoter);
                default:
                    return false;
            }
        }

        private bool HasPermissionToCreateBachelorProposal(Promoter promoter)
        {
            var numOfSubmittedProposals = CountSubmittedProposals(promoter, StudyLevel.Bachelor);
            if (numOfSubmittedProposals < promoter.ExpectedNumberOfBachelorProposals) 
            {
                return true;
            }
            return false;
        }

        private bool HasPermissionToCreateMasterProposal(Promoter promoter)
        {
            var numOfSubmittedProposals = CountSubmittedProposals(promoter, StudyLevel.Master);
            if (numOfSubmittedProposals < promoter.ExpectedNumberOfMasterProposals) 
            {
                return true;
            }
            return false;
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

        private int CountSubmittedProposals(Promoter promoter, StudyLevel level)
        {
            if (promoter == null)
            {
                return 0;
            }
            return promoter
                .Proposals
                .Count(p => p.Level == level);
        }

        private void SetStartDate(Proposal proposal)
        {
            var level = proposal.Level;
            if(level == StudyLevel.Bachelor)
            {
                var startingDate = _systemSettingsGetter.GetSystemSettings().BachelorThesisStartDate;
                proposal.StartingDate = startingDate;
            }
            else
            {
                var startingDate = _systemSettingsGetter.GetSystemSettings().MasterThesisStartDate;
                proposal.StartingDate = startingDate;
            }
        }
    }
}
