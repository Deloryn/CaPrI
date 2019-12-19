using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Capri.Database;
using Capri.Web.ViewModels.Faculty;

namespace Capri.Services.Faculties
{
    public class FacultyDeleter : IFacultyDeleter
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFacultyGetter _facultyGetter;

        public FacultyDeleter(
            ISqlDbContext context,
            IMapper mapper,
            IFacultyGetter facultyGetter
            )
        {
            _context = context;
            _mapper = mapper;
            _facultyGetter = facultyGetter;
        }

        public async Task<IServiceResult<FacultyView>> Delete(Guid id)
        {
            var faculty = await _context.Faculties.FirstOrDefaultAsync(f => f.Id.Equals(id));
            
            if(faculty == null)
            {
                return ServiceResult<FacultyView>.Error("There is no faculty with id " + id);
            }

            _context.Faculties.Remove(faculty);
            await _context.SaveChangesAsync();

            var facultyView = _mapper.Map<FacultyView>(faculty);
            return ServiceResult<FacultyView>.Success(facultyView);
        }
    }
}