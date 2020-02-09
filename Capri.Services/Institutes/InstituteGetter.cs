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

        public async Task<IServiceResult<InstituteViewModel>> Get(int id)
        {
            var institute = await _context.Institutes
                .Include(i => i.Promoters)
                .FirstOrDefaultAsync(i => i.Id == id);

            if(institute == null)
            {
                return ServiceResult<InstituteViewModel>.Error(
                    $"Institute with id {id} does not exist");
            }

            var instituteViewModel = _mapper.Map<InstituteViewModel>(institute);
            return ServiceResult<InstituteViewModel>.Success(instituteViewModel);
        }
        public IServiceResult<IEnumerable<InstituteViewModel>> GetAll()
        {
            var institutes = _context.Institutes
                .Include(i => i.Promoters);
                
            var instituteViewModels = institutes.Select(i => _mapper.Map<InstituteViewModel>(i));
            return ServiceResult<IEnumerable<InstituteViewModel>>.Success(instituteViewModels);
        }
    }
}