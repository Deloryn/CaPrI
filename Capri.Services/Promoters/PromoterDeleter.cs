using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Capri.Database;
using Capri.Web.ViewModels.Promoter;

namespace Capri.Services.Promoters
{
    public class PromoterDeleter : IPromoterDeleter
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;

        public PromoterDeleter(
            ISqlDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

            var applicationUser = 
                await _context
                .Users
                .FirstOrDefaultAsync(u => u.Id == promoter.UserId);

            _context.Promoters.Remove(promoter);
            _context.Users.Remove(applicationUser);

            await _context.SaveChangesAsync();

            var promoterViewModel = _mapper.Map<PromoterViewModel>(promoter);
            return ServiceResult<PromoterViewModel>.Success(promoterViewModel);
        }
    }
}
