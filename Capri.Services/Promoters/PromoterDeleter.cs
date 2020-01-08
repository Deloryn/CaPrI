using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Capri.Database;
using Capri.Database.Entities.Identity;
using Capri.Web.ViewModels.Promoter;

namespace Capri.Services.Promoters
{
    public class PromoterDeleter : IPromoterDeleter
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public PromoterDeleter(
            ISqlDbContext context,
            IMapper mapper,
            UserManager<User> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
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

            var applicationUser = 
                await _context
                .Users
                .FirstOrDefaultAsync(u => u.Id == promoter.UserId);

            await _userManager.DeleteAsync(applicationUser);
            await _context.SaveChangesAsync();

            return ServiceResult<PromoterViewModel>.Success(promoterViewModel);
        }
    }
}
