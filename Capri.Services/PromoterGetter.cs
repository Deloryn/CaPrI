﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Capri.Database;
using Capri.Database.Entities;

namespace Capri.Services
{
    public class PromoterGetter : IPromoterGetter
    {
        private readonly ISqlDbContext _context;

        public PromoterGetter(ISqlDbContext context)
        {
            _context = context;
        }

        public async Task<IServiceResult<Promoter>> Get(Guid id)
        {
            var promoter = await _context.Promoters.FirstOrDefaultAsync(p => p.Id == id);

            if (promoter == null)
            {
                return ServiceResult<Promoter>.Error(
                    "Promoter with given id does not exist");
            }

            return ServiceResult<Promoter>.Success(promoter);
        }

        public IServiceResult<IEnumerable<Promoter>> GetAll()
        {
            var promoters = _context.Promoters;
            return ServiceResult<IEnumerable<Promoter>>.Success(promoters);
        }
    }
}
