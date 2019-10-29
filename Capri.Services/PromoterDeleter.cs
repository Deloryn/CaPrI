﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Capri.Database;
using Capri.Database.Entities;
using Capri.Database.Entities.Identity;
using Capri.Web.ViewModels.Promoter;

namespace Capri.Services
{
    public class PromoterDeleter : IPromoterDeleter
    {
        private readonly ISqlDbContext _context;

        public PromoterDeleter(ISqlDbContext context)
        {
            _context = context;
        }

        public IServiceResult<Promoter> Delete(Guid id)
        {
            Promoter promoter = _context.Promoters.Find(id);
            if(promoter == null)
            {
                return ServiceResult<Promoter>.Error(
                    "Promoter with the given id does not exist");
            }
            else
            {
                _context.Promoters.Remove(promoter);
                return ServiceResult<Promoter>.Success(promoter);
            }
        }
    }
}
