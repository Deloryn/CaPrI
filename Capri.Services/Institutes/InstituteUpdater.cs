using System;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using Capri.Database;
using Capri.Web.ViewModels.Institute;

namespace Capri.Services.Institutes
{
    public class InstituteUpdater : IInstituteUpdater
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;

        public InstituteUpdater(
            ISqlDbContext context, 
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IServiceResult<InstituteViewModel>> Update(
            Guid id, 
            InstituteRegistration newData)
        {
            var institute = _context.Institutes.FirstOrDefault(i => i.Id == id);

            if (institute == null)
            {
                return ServiceResult<InstituteViewModel>.Error(
                    $"Institute with id {id} does not exist");
            }

            institute = _mapper.Map(newData, institute);

            _context.Institutes.Update(institute);
            await _context.SaveChangesAsync();

            var instituteViewModel = _mapper.Map<InstituteViewModel>(institute);
            return ServiceResult<InstituteViewModel>.Success(instituteViewModel);
        }
    }
}