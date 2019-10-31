using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Capri.Database;
using Capri.Database.Entities;
using Capri.Database.Entities.Identity;
using Capri.Web.ViewModels.Promoter;

namespace Capri.Services
{
    public class PromoterUpdater : IPromoterUpdater
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;

        public PromoterUpdater(
            ISqlDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IServiceResult<Promoter>> Update(
            Guid id,
            PromoterUpdate newData)
        {
            var existingPromoter = 
                await _context
                .Promoters
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existingPromoter == null)
            {
                return ServiceResult<Promoter>.Error(
                    "Promoter with the given does not exist");
            }

            var existingUser = 
                await _context
                .Users
                .FirstOrDefaultAsync(u => u.Id == newData.UserId);

            if (existingUser == null)
            {
                return ServiceResult<Promoter>.Error(
                    "User with the given id does not exist");
            }

            existingPromoter = _mapper.Map<Promoter>(newData);
            existingPromoter.Id = id;

            _context.Promoters.Update(existingPromoter);
            await _context.SaveChangesAsync();

            return ServiceResult<Promoter>.Success(existingPromoter);
        }
    }
}
