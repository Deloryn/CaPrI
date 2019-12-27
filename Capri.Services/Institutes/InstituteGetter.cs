using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Capri.Database;
using Capri.Web.ViewModels.Institute;

namespace Capri.Services.Institutes
{
    public class InstituteGetter : IInstituteGetter
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
        
        public InstituteGetter(
            ISqlDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IServiceResult<InstituteView>> Get(Guid id)
        {
            var institute = await _context.Institutes
                .Include(i => i.Promoters)
                .FirstOrDefaultAsync(i => i.Id.Equals(id));

            if(institute == null)
            {
                return ServiceResult<InstituteView>.Error("Institute with id " + id + " does not exist");
            }

            var instituteView = _mapper.Map<InstituteView>(institute);
            return ServiceResult<InstituteView>.Success(instituteView);
        }
        public IServiceResult<IEnumerable<InstituteView>> GetAll()
        {
            var institutes = _context.Institutes
                .Include(i => i.Promoters);
                
            var instituteViews = institutes.Select(i => _mapper.Map<InstituteView>(i));
            return ServiceResult<IEnumerable<InstituteView>>.Success(instituteViews);
        }
    }
}