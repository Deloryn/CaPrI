using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Capri.Database;
using Capri.Database.Entities;
using Capri.Web.ViewModels.Faculty;

namespace Capri.Services.Faculties
{
    public class FacultyCreator : IFacultyCreator
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;

        public FacultyCreator(
            ISqlDbContext context,
            IMapper mapper
        )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IServiceResult<FacultyViewModel>> Create(FacultyRegistration registration)
        {
            if(DoesFacultyNameExist(registration.Name))
            {
                return ServiceResult<FacultyViewModel>.Error(
                    $"Faculty name {registration.Name} already exists"
                );
            }

            var faculty = _mapper.Map<Faculty>(registration);

            await _context.Faculties.AddAsync(faculty);
            await _context.SaveChangesAsync();

            var facultyViewModel = _mapper.Map<FacultyViewModel>(faculty);
            return ServiceResult<FacultyViewModel>.Success(facultyViewModel);
        }

        private bool DoesFacultyNameExist(string name)
        {
            return _context
                .Faculties
                .Any(i => i.Name == name);
        }
    }
}