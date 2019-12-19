using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Capri.Database;
using Capri.Web.ViewModels.Faculty;

namespace Capri.Services.Faculties
{
    public class FacultyGetter : IFacultyGetter
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
        
        public FacultyGetter(
            ISqlDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IServiceResult<FacultyView>> Get(Guid id)
        {
            var faculty = await _context.Faculties.FirstOrDefaultAsync(f => f.Id == id);

            if(faculty == null)
            {
                return ServiceResult<FacultyView>.Error("Faculty with id " + id + " does not exist");
            }

            var facultyView = _mapper.Map<FacultyView>(faculty);
            return ServiceResult<FacultyView>.Success(facultyView);
        }
        public IServiceResult<IEnumerable<FacultyView>> GetAll()
        {
            var faculties = _context.Faculties;
            var facultyViews = faculties.Select(f => _mapper.Map<FacultyView>(f));
            return ServiceResult<IEnumerable<FacultyView>>.Success(facultyViews);
        }
    }
}