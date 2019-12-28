﻿using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Capri.Database;
using Capri.Services.Users;
using Capri.Web.ViewModels.Promoter;
using Capri.Web.ViewModels.User;

namespace Capri.Services.Promoters
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

        public async Task<IServiceResult<PromoterViewModel>> Update(
            Guid id,
            PromoterRegistration newData)
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

            var credentials = new UserCredentials
            {
                Email = newData.Email,
                Password = newData.Password
            };

            var result = await _userUpdater.Update(
                existingPromoter.UserId, 
                credentials);

            if (!result.Successful())
            {
                var errors = result.GetAggregatedErrors();
                return ServiceResult<PromoterViewModel>.Error(errors);
            }
            
            existingPromoter = _mapper.Map(newData, existingPromoter);

            _context.Promoters.Update(existingPromoter);
            await _context.SaveChangesAsync();

            var promoterViewModel = _mapper.Map<PromoterViewModel>(existingPromoter);
            return ServiceResult<PromoterViewModel>.Success(promoterViewModel);
        }
    }
}
