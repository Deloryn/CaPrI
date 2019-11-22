using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Capri.Database;
using Capri.Database.Entities;
using Capri.Web.ViewModels.Promoter;
using Capri.Web.ViewModels.User;

namespace Capri.Services
{
    public class PromoterUpdater : IPromoterUpdater
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserUpdater _userUpdater;

        public PromoterUpdater(
            ISqlDbContext context,
            IMapper mapper,
            IUserUpdater userUpdater)
        {
            _context = context;
            _mapper = mapper;
            _userUpdater = userUpdater;
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

            var credentials = new UserCredentials
            {
                Email = newData.Email,
                Password = newData.Password
            };

            var result = await _userUpdater.Update(newData.UserId, credentials);
            if (!result.Successful())
            {
                var errors = result.GetAggregatedErrors();
                return ServiceResult<Promoter>.Error(errors);
            }

            existingPromoter = _mapper.Map<Promoter>(newData);
            existingPromoter.Id = id;

            _context.Promoters.Update(existingPromoter);
            await _context.SaveChangesAsync();

            return ServiceResult<Promoter>.Success(existingPromoter);
        }
    }
}
