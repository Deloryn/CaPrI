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

        public async Task<IServiceResult<InstituteView>> Update(
            Guid id, 
            InstituteRegistration newData)
        {
            var institute = _context.Institutes.FirstOrDefault(i => i.Id.Equals(id));

            if (institute == null)
            {
                return ServiceResult<InstituteView>.Error("There is no institute with id " + id);
            }

            institute = _mapper.Map(newData, institute);

            _context.Institutes.Update(institute);
            await _context.SaveChangesAsync();

            var instituteView = _mapper.Map<InstituteView>(institute);
            return ServiceResult<InstituteView>.Success(instituteView);
        }
    }
}