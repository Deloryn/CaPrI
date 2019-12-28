using System;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using Capri.Database;
using Capri.Web.ViewModels.Faculty;

namespace Capri.Services.Faculties
{
    public class FacultyUpdater : IFacultyUpdater
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;

        public FacultyUpdater(
            ISqlDbContext context, 
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IServiceResult<FacultyViewModel>> Update(
            Guid id, 
            FacultyRegistration newData)
        {
            var faculty = _context.Faculties.FirstOrDefault(f => f.Id == id);

            if (faculty == null)
            {
                return ServiceResult<FacultyViewModel>.Error(
                    $"Faculty with id {id} does not exist");
            }

            faculty = _mapper.Map(newData, faculty);

            _context.Faculties.Update(faculty);
            await _context.SaveChangesAsync();

            var facultyViewModel = _mapper.Map<FacultyViewModel>(faculty);
            return ServiceResult<FacultyViewModel>.Success(facultyViewModel);
        }
    }
}