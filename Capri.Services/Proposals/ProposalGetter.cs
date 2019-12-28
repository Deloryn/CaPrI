using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Sieve.Models;
using Sieve.Services;
using Capri.Database;
using Capri.Web.ViewModels.Proposal;

namespace Capri.Services.Proposals
{
    public class ProposalGetter : IProposalGetter
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
        private readonly ISieveProcessor _sieveProcessor;

        public ProposalGetter(
            ISqlDbContext context,
            IMapper mapper,
            ISieveProcessor sieveProcessor)
        {
            _context = context;
            _mapper = mapper;
            _sieveProcessor = sieveProcessor;
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

        public IServiceResult<IEnumerable<ProposalViewModel>> GetAll()
        {
            var proposals = _context.Proposals
                .Include(p => p.Students);

            var proposalViewModels = proposals.Select(p => _mapper.Map<ProposalViewModel>(p));
            return ServiceResult<IEnumerable<ProposalViewModel>>.Success(proposalViewModels);
        }

        public IServiceResult<IQueryable<ProposalViewModel>> GetFiltered(SieveModel sieveModel)
        {
            var proposals = _context.Proposals
                .Include(p => p.Students)
                .AsQueryable();

            var filtered = _sieveProcessor.Apply(sieveModel, proposals);
            
            var proposalViewModels = filtered.Select(p => _mapper.Map<ProposalViewModel>(p));
            return ServiceResult<IQueryable<ProposalViewModel>>.Success(proposalViewModels);
        }
    }
}
