using System;
using System.Threading.Tasks;
using AutoMapper;
using Capri.Database;
using Capri.Database.Entities;
using Capri.Services.Users;
using Capri.Services.Institutes;
using Capri.Web.ViewModels.Promoter;

namespace Capri.Services.Promoters
{
    public class PromoterCreator : IPromoterCreator
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserCreator _userCreator;
        private readonly IInstituteGetter _instituteGetter;

        public PromoterCreator(
            ISqlDbContext context,
            IMapper mapper,
            IUserCreator userCreator,
            IInstituteGetter instituteGetter
            )
        {
            _context = context;
            _mapper = mapper;
            _userCreator = userCreator;
            _instituteGetter = instituteGetter;
        }

        public async Task<IServiceResult<PromoterViewModel>> Create(
            PromoterRegistration registration,
            bool passwordHashed = false)
        {
            var instituteResult = await _instituteGetter.Get(registration.InstituteId);
            if(!instituteResult.Successful())
            {
                return ServiceResult<PromoterViewModel>.Error(instituteResult.GetAggregatedErrors());
            }

            var userResult = 
                await _userCreator
                .CreateUser(registration.Email, registration.Password, passwordHashed);

            if(!userResult.Successful())
            {
                var errors = userResult.GetAggregatedErrors();
                return ServiceResult<PromoterViewModel>.Error(errors);
            }

            var user = userResult.Body();
            var promoter = _mapper.Map<Promoter>(registration);
            promoter.Id = Guid.NewGuid();
            promoter.UserId = user.Id;

            await _context.Promoters.AddAsync(promoter);
            await _context.SaveChangesAsync();

            var promoterViewModel = _mapper.Map<PromoterViewModel>(promoter);
            return ServiceResult<PromoterViewModel>.Success(promoterViewModel);
        }
    }
}
