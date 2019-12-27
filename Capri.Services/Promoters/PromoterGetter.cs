using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Capri.Database;
using Capri.Web.ViewModels.Promoter;

namespace Capri.Services.Promoters
{
    public class PromoterGetter : IPromoterGetter
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;

        public PromoterGetter(
            ISqlDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IServiceResult<PromoterView>> Get(Guid id)
        {
            var promoter = 
                await _context
                .Promoters
                .Include(p => p.Proposals)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (promoter == null)
            {
                return ServiceResult<PromoterView>.Error("Promoter with id " + id + " does not exist");
            }

            var promoterView = _mapper.Map<PromoterView>(promoter);
            return ServiceResult<PromoterView>.Success(promoterView);
        }

        public IServiceResult<IEnumerable<PromoterView>> GetAll()
        {
            var promoters = _context.Promoters
                .Include(p => p.Proposals);
                
            var promoterViews = promoters.Select(p => _mapper.Map<PromoterView>(p));
            return ServiceResult<IEnumerable<PromoterView>>.Success(promoterViews);
        }
    }
}
