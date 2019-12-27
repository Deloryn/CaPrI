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

        public async Task<IServiceResult<FacultyView>> Update(
            Guid id, 
            FacultyRegistration newData)
        {
            var faculty = _context.Faculties.FirstOrDefault(f => f.Id.Equals(id));

            if (faculty == null)
            {
                return ServiceResult<FacultyView>.Error(
                    $"Faculty with id {id} does not exist");
            }

            faculty = _mapper.Map(newData, faculty);

            _context.Faculties.Update(faculty);
            await _context.SaveChangesAsync();

            var facultyView = _mapper.Map<FacultyView>(faculty);
            return ServiceResult<FacultyView>.Success(facultyView);
        }
    }
}