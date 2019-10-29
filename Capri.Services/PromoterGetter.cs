﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public IServiceResult<Promoter> Get(Guid id)
        {
            var promoter = _context.Promoters.Find(id);
            if (promoter == null)
            {
                return ServiceResult<Promoter>.Error(
                    "Promoter with given id does not exist");
            }
            else
            {
                return ServiceResult<Promoter>.Success(promoter);
            }
        }

        public IServiceResult<List<Promoter>> GetAll()
        {
            var promoters = _context.Promoters.ToList();
            return ServiceResult<List<Promoter>>.Success(promoters);
        }
    }
}
