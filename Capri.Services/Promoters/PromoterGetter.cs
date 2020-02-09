using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Sieve.Models;
using Sieve.Services;
using Capri.Database;
using Capri.Services.Users;
using Capri.Web.ViewModels.Promoter;

namespace Capri.Services.Promoters
{
    public class PromoterGetter : IPromoterGetter
    {
        private readonly ISqlDbContext _context;
        private readonly IUserGetter _userGetter;
        private readonly IMapper _mapper;
        private readonly ISieveProcessor _sieveProcessor;

        public PromoterGetter(
            ISqlDbContext context,
            IUserGetter userGetter,
            IMapper mapper,
            ISieveProcessor sieveProcessor)
        {
            _context = context;
            _userGetter = userGetter;
            _mapper = mapper;
            _sieveProcessor = sieveProcessor;
        }

        public IServiceResult<int> Count(SieveModel sieveModel)
        {
            var promoters = _context.Promoters.AsQueryable();
            var filtered = _sieveProcessor.Apply(sieveModel, promoters, null, true, true, false);
            var total = filtered.Count();
            
            return ServiceResult<int>.Success(total);
        }

        public async Task<IServiceResult<PromoterViewModel>> Get(int id)
        {
            var promoter = 
                await _context
                .Promoters
                .Include(p => p.Proposals)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (promoter == null)
            {
                return ServiceResult<PromoterViewModel>.Error(
                    $"Promoter with id {id} does not exist");
            }

            var promoterViewModel = _mapper.Map<PromoterViewModel>(promoter);
            return ServiceResult<PromoterViewModel>.Success(promoterViewModel);
        }

        public IServiceResult<IEnumerable<PromoterViewModel>> GetAll()
        {
            var promoters = _context.Promoters
                .Include(p => p.Proposals);
                
            var promoterViewModels = promoters.Select(p => _mapper.Map<PromoterViewModel>(p));
            return ServiceResult<IEnumerable<PromoterViewModel>>.Success(promoterViewModels);
        }

        public IServiceResult<IQueryable<PromoterViewModel>> GetFiltered(SieveModel sieveModel)
        {
            var promoters = _context.Promoters.AsQueryable();
            var filtered = _sieveProcessor.Apply(sieveModel, promoters);
            var promoterViewModels = filtered.Select(p => _mapper.Map<PromoterViewModel>(p));

            return ServiceResult<IQueryable<PromoterViewModel>>.Success(promoterViewModels);
        }

        public async Task<IServiceResult<PromoterViewModel>> GetMyData()
        {
            var userResult = await _userGetter.GetCurrentUser();
            if(!userResult.Successful())
            {
                var errors = userResult.GetAggregatedErrors();
                return ServiceResult<PromoterViewModel>.Error(errors);
            }

            var currentUser = userResult.Body();
            var promoter = 
                await _context
                .Promoters
                .Include(p => p.Proposals)
                .FirstOrDefaultAsync(p => p.UserId == currentUser.Id);

            if(promoter == null)
            {
                return ServiceResult<PromoterViewModel>.Error("The current user has no associated promoter");
            }

            var promoterViewModel = _mapper.Map<PromoterViewModel>(promoter);
            return ServiceResult<PromoterViewModel>.Success(promoterViewModel);
        }
    }
}
