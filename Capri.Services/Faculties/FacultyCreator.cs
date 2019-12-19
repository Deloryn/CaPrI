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

        public async Task<IServiceResult<FacultyView>> Create(FacultyRegistration registration)
        {
            var faculty = _mapper.Map<Faculty>(registration);

            try 
            {
                await _context.Faculties.AddAsync(faculty);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return ServiceResult<FacultyView>.Error("Failed to create a faculty from the given data");
            }

            var facultyView = _mapper.Map<FacultyView>(faculty);
            return ServiceResult<FacultyView>.Success(facultyView);
        }
    }
}