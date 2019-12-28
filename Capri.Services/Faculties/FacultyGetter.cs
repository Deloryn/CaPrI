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

        public async Task<IServiceResult<FacultyViewModel>> Get(Guid id)
        {
            var faculty = await _context.Faculties
                .Include(f => f.Courses)
                .FirstOrDefaultAsync(f => f.Id == id);

            if(faculty == null)
            {
                return ServiceResult<FacultyViewModel>.Error(
                    $"Faculty with id {id} does not exist");
            }

            var facultyViewModel = _mapper.Map<FacultyViewModel>(faculty);
            return ServiceResult<FacultyViewModel>.Success(facultyViewModel);
        }
        public IServiceResult<IEnumerable<FacultyViewModel>> GetAll()
        {
            var faculties = _context.Faculties
                .Include(f => f.Courses);

            var facultyViewModels = faculties.Select(f => _mapper.Map<FacultyViewModel>(f));
            return ServiceResult<IEnumerable<FacultyViewModel>>.Success(facultyViewModels);
        }
    }
}