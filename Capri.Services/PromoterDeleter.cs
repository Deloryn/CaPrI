using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IServiceResult<Promoter>> Delete(Guid id)
        {
            var promoter = 
                await _context
                .Promoters
                .FirstOrDefaultAsync(_ => _.Id == id);

            if(promoter == null)
            {
                return ServiceResult<Promoter>.Error(
                    "Promoter with the given id does not exist");
            }

            _context.Promoters.Remove(promoter);
            return ServiceResult<Promoter>.Success(promoter);
        }
    }
}
