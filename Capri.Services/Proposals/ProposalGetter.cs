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

        public async Task<IServiceResult<ProposalView>> Get(Guid id)
        {
            var proposal = await _context.Proposals.FirstOrDefaultAsync(p => p.Id == id);

            if(proposal == null)
            {
                return ServiceResult<ProposalView>.Error("Proposal with id " + id + " does not exist");
            }

            var proposalView = _mapper.Map<ProposalView>(proposal);
            return ServiceResult<ProposalView>.Success(proposalView);
        }

        public IServiceResult<IEnumerable<ProposalView>> GetAll()
        {
            var proposals = _context.Proposals;
            var proposalViews = proposals.Select(p => _mapper.Map<ProposalView>(p));
            return ServiceResult<IEnumerable<ProposalView>>.Success(proposalViews);
        }

        public IServiceResult<IQueryable<ProposalView>> GetFiltered(SieveModel sieveModel)
        {
            var proposals = _context.Proposals.AsQueryable();
            var filtered = _sieveProcessor.Apply(sieveModel, proposals);
            var proposalViews = filtered.Select(p => _mapper.Map<ProposalView>(p));
            return ServiceResult<IQueryable<ProposalView>>.Success(proposalViews);
        }
    }
}
