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
using Capri.Web.ViewModels.Proposal;
using Capri.Web.ViewModels.Common;

namespace Capri.Services.Proposals
{
    public class ProposalGetter : IProposalGetter
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
        private readonly ISieveProcessor _sieveProcessor;
        private readonly ICsvCreator _csvCreator;

        public ProposalGetter(
            ISqlDbContext context,
            IMapper mapper,
            ISieveProcessor sieveProcessor,
            ICsvCreator csvCreator)
        {
            _context = context;
            _mapper = mapper;
            _sieveProcessor = sieveProcessor;
            _csvCreator = csvCreator;
        }

        public async Task<IServiceResult<ProposalViewModel>> Get(int id)
        {
            var proposal = await _context.Proposals
                .Include(p => p.StudentIndexNumbers)
                .FirstOrDefaultAsync(p => p.Id == id);

            if(proposal == null)
            {
                return ServiceResult<ProposalViewModel>.Error(
                    $"Proposal with id {id} does not exist");
            }

            var proposalViewModel = _mapper.Map<ProposalViewModel>(proposal);
            return ServiceResult<ProposalViewModel>.Success(proposalViewModel);
        }

        public async Task<IServiceResult<FileDescription>> GetCsvFileDescription(int id)
        {
            var proposal = await _context.Proposals
                .Include(p => p.StudentIndexNumbers)
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

        public IServiceResult<IEnumerable<ProposalViewModel>> GetAll()
        {
            var proposals = _context.Proposals;
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
