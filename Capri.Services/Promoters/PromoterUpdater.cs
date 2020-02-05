using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Capri.Database;
using Capri.Database.Entities.Identity;
using Capri.Services.Users;
using Capri.Services.Institutes;
using Capri.Web.ViewModels.Promoter;
using Capri.Web.ViewModels.User;

namespace Capri.Services.Promoters
{
    public class PromoterUpdater : IPromoterUpdater
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
        private readonly IInstituteGetter _instituteGetter;

        public PromoterUpdater(
            ISqlDbContext context,
            IMapper mapper,
            IInstituteGetter instituteGetter)
        {
            _context = context;
            _mapper = mapper;
            _instituteGetter = instituteGetter;
        }

        public async Task<IServiceResult<PromoterViewModel>> Update(
            int id,
            PromoterUpdate newData)
        {
            var existingPromoter = 
                await _context
                .Promoters
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existingPromoter == null)
            {
                return ServiceResult<PromoterViewModel>.Error(
                    $"Promoter with id {id} does not exist");
            }
            
            existingPromoter = _mapper.Map(newData, existingPromoter);

            _context.Promoters.Update(existingPromoter);
            await _context.SaveChangesAsync();

            var promoterViewModel = _mapper.Map<PromoterViewModel>(existingPromoter);
            return ServiceResult<PromoterViewModel>.Success(promoterViewModel);
        }
    }
}
