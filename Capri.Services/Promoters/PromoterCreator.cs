using System;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using AutoMapper;
using Capri.Database;
using Capri.Database.Entities;
using Capri.Services.Users;
using Capri.Web.ViewModels.Promoter;

namespace Capri.Services.Promoters
{
    public class PromoterCreator : IPromoterCreator
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
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
                var errors = result.GetAggregatedErrors();
                return ServiceResult<Promoter>.Error(errors);
            }

            var user = result.Body();

            var promoter = _mapper.Map<Promoter>(registration);
            promoter.Id = Guid.NewGuid();
            promoter.UserId = user.Id;

            await _context.Promoters.AddAsync(promoter);
            await _context.SaveChangesAsync();

            return ServiceResult<Promoter>.Success(promoter);
        }
    }
}
