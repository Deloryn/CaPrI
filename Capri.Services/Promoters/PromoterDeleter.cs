using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Capri.Database;
using Capri.Services.Users;
using Capri.Web.ViewModels.Promoter;

namespace Capri.Services.Promoters
{
    public class PromoterDeleter : IPromoterDeleter
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserDeleter _userDeleter;

        public PromoterDeleter(
            ISqlDbContext context,
            IMapper mapper,
            IUserDeleter userDeleter)
        {
            _context = context;
            _mapper = mapper;
            _userDeleter = userDeleter;
        }

        public async Task<IServiceResult<PromoterViewModel>> Delete(Guid id)
        {
            var promoter = 
                await _context
                .Promoters
                .FirstOrDefaultAsync(p => p.Id == id);

            if(promoter == null)
            {
                return ServiceResult<PromoterViewModel>.Error(
                    $"Promoter with id {id} does not exist");
            }

            var promoterViewModel = _mapper.Map<PromoterViewModel>(promoter);

            var userResult = await _userDeleter.Delete(promoter.UserId);
            if(!userResult.Successful())
            {
                return ServiceResult<PromoterViewModel>.Error(userResult.GetAggregatedErrors());
            }
            
            return ServiceResult<PromoterViewModel>.Success(promoterViewModel);
        }
    }
}
