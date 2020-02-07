using System.Text;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Sieve.Models;
using Sieve.Services;
using Capri.Database;
using Capri.Services.Files;
using Capri.Services.Users;
using Capri.Web.ViewModels.Proposal;
using Capri.Web.ViewModels.Common;
using System.IO;

namespace Capri.Services.Proposals
{
    public class ProposalGetter : IProposalGetter
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
        private readonly ISieveProcessor _sieveProcessor;
        private readonly ICsvCreator _csvCreator;
        private readonly IUserGetter _userGetter;
        private readonly IDiplomaCardCreator _diplomaCardCreator;

        public ProposalGetter(
            ISqlDbContext context,
            IMapper mapper,
            ISieveProcessor sieveProcessor,
            ICsvCreator csvCreator,
            IUserGetter userGetter,
            IDiplomaCardCreator diplomaCardCreator)
        {
            _context = context;
            _mapper = mapper;
            _sieveProcessor = sieveProcessor;
            _csvCreator = csvCreator;
            _userGetter = userGetter;
            _diplomaCardCreator = diplomaCardCreator;
        }

        public async Task<IServiceResult<ProposalViewModel>> Get(Guid id)
        {
            var proposal = await _context.Proposals
                .Include(p => p.Students)
                .FirstOrDefaultAsync(p => p.Id == id);

            if(proposal == null)
            {
                return ServiceResult<ProposalViewModel>.Error(
                    $"Proposal with id {id} does not exist");
            }

            var proposalViewModel = _mapper.Map<ProposalViewModel>(proposal);
            return ServiceResult<ProposalViewModel>.Success(proposalViewModel);
        }

        public async Task<IServiceResult<FileDescription>> GetCsvFileDescription(Guid id)
        {
            var proposal = await _context.Proposals
                .Include(p => p.Students)
                .Include(p => p.Course.Faculty)
                .Include(p => p.Promoter.Institute)
                .FirstOrDefaultAsync(p => p.Id == id);

            if(proposal == null)
            {
                return ServiceResult<FileDescription>.Error(
                    $"Proposal with id {id} does not exist");
            }
            
            var proposalCsvRecord = _mapper.Map<ProposalCsvRecord>(proposal);
            var records = new ProposalCsvRecord[] { proposalCsvRecord };

            var csvStringResult = _csvCreator.CreateCsvStringFrom<ProposalCsvRecord>(records);
            if(!csvStringResult.Successful())
            {
                return ServiceResult<FileDescription>.Error(csvStringResult.GetAggregatedErrors());
            }

            var csvString = csvStringResult.Body();
            var bytes = Encoding.UTF8.GetBytes(csvString);
            var fileName = $"proposal-{proposal.Id}.csv";

            var fileDescription = new FileDescription {
                Name = fileName,
                Bytes = bytes
            };

            return ServiceResult<FileDescription>.Success(fileDescription);
        }

        public async Task<IServiceResult<IEnumerable<ProposalViewModel>>> GetMyProposals() {
            var userResult = await _userGetter.GetCurrentUser();
            if (!userResult.Successful())
            {
                var errors = userResult.GetAggregatedErrors();
                return ServiceResult<IEnumerable<ProposalViewModel>>.Error(errors);
            }

            var currentUser = userResult.Body();
            var promoter =
                await _context
                .Promoters
                .Include(p => p.Proposals)
                .FirstOrDefaultAsync(p => p.UserId == currentUser.Id);

            if (promoter == null)
            {
                return ServiceResult<IEnumerable<ProposalViewModel>>.Error("The current user has no associated promoter");
            }

            var proposalViewModels = promoter
                .Proposals
                .Select(p => _mapper.Map<ProposalViewModel>(p));

            return ServiceResult<IEnumerable<ProposalViewModel>>.Success(proposalViewModels);
        }

        public async Task<IServiceResult<FileDescription>> GetDiplomaCard(Guid id)
        {
            var proposal = await _context.Proposals
                .Include(p => p.Students)
                .Include(p => p.Course.Faculty)
                .Include(p => p.Promoter.Institute)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (proposal == null)
            {
                return ServiceResult<FileDescription>.Error($"Proposal with id {id} does not exist.");
            }

            var proposalDocRecord = _mapper.Map<ProposalDocRecord>(proposal);

            var result = _diplomaCardCreator.CreateDiplomaCard(proposalDocRecord);

            var fileName = $"karta_tematu_pracy_{proposal.Id}.docx";

            var fileDescription = new FileDescription {
                Name = fileName,
                Bytes = result.Body().ToArray()
            };

            return ServiceResult<FileDescription>.Success(fileDescription);
        }

        public IServiceResult<IEnumerable<ProposalViewModel>> GetAll()
        {
            var proposals = _context.Proposals
                .Include(p => p.Students);

            var proposalViewModels = proposals.Select(p => _mapper.Map<ProposalViewModel>(p));
            return ServiceResult<IEnumerable<ProposalViewModel>>.Success(proposalViewModels);
        }

        public IServiceResult<IQueryable<ProposalViewModel>> GetFiltered(SieveModel sieveModel)
        {
            var proposals = _context.Proposals.AsQueryable();

            var filtered = _sieveProcessor.Apply(sieveModel, proposals);
            
            var proposalViewModels = filtered.Select(p => _mapper.Map<ProposalViewModel>(p));
            return ServiceResult<IQueryable<ProposalViewModel>>.Success(proposalViewModels);
        }
    }
}
