using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using Capri.Database;
using Capri.Database.Entities;
using Capri.Web.ViewModels.Promoter;

namespace Capri.Services
{
    public class PromoterCreator : IPromoterCreator
    {
        private readonly ISqlDbContext _context;
        private readonly IUserCreator _userCreator;

        public PromoterCreator(
            ISqlDbContext context,
            IUserCreator userCreator)
        {
            _context = context;
            _userCreator = userCreator;
        }

        public async Task<IServiceResult<Promoter>> Create(
            PromoterRegistration registration)
        {

            var result = 
                await _userCreator
                .CreateUser(registration.Email, registration.Password);

            if(!result.Successful())
            {
                var errors = result.Errors();
                return ServiceResult<Promoter>.Error(errors);
            }

            var user = result.Body();

            var promoter = new Promoter
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                CanSubmitBachelorProposals = registration.CanSubmitBachelorProposals,
                CanSubmitMasterProposals = registration.CanSubmitMasterProposals
            };

            await _context.Promoters.AddAsync(promoter);
            await _context.SaveChangesAsync();

            return ServiceResult<Promoter>.Success(promoter);
        }
    }
}
