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
            if(institute == null)
            {
                return ServiceResult<InstituteViewModel>.Error(
                    $"Institute with id {id} does not exist");
            }

            if(IsNameTakenByAnotherInstitute(institute.Id, newData.Name))
            {
                return ServiceResult<InstituteViewModel>.Error(
                    $"Institute name {newData.Name} already exists"
                );
            }

            institute = _mapper.Map(newData, institute);

            _context.Institutes.Update(institute);
            await _context.SaveChangesAsync();

            var instituteViewModel = _mapper.Map<InstituteViewModel>(institute);
            return ServiceResult<InstituteViewModel>.Success(instituteViewModel);
        }

        private bool IsNameTakenByAnotherInstitute(Guid myInstituteId, string name)
        {
            return _context
                .Institutes
                .Any(i => i.Name == name && i.Id != myInstituteId);
        }
    }
}