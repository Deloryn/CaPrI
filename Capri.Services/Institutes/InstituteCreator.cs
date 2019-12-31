using System.Threading.Tasks;
using AutoMapper;
using Capri.Database;
using Capri.Database.Entities;
using Capri.Web.ViewModels.Institute;

namespace Capri.Services.Institutes
{
    public class InstituteCreator : IInstituteCreator
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;

        public InstituteCreator(
            ISqlDbContext context,
            IMapper mapper
        )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IServiceResult<InstituteViewModel>> Create(InstituteRegistration registration)
        {
            var institute = _mapper.Map<Institute>(registration);

            await _context.Institutes.AddAsync(institute);
            await _context.SaveChangesAsync();

            var instituteViewModel = _mapper.Map<InstituteViewModel>(institute);
            return ServiceResult<InstituteViewModel>.Success(instituteViewModel);
        }
    }
}