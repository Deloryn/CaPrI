using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Capri.Database;
using Capri.Web.ViewModels.Student;

namespace Capri.Services.Students
{
    public class StudentGetter : IStudentGetter
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
        
        public StudentGetter(
            ISqlDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IServiceResult<StudentViewModel>> Get(Guid id)
        {
            var student = 
                await _context
                .Students
                .FirstOrDefaultAsync(p => p.Id == id);

            if (student == null)
            {
                return ServiceResult<StudentViewModel>.Error(
                    $"Student with id {id} does not exist");
            }

            var studentViewModel = _mapper.Map<StudentViewModel>(student);
            return ServiceResult<StudentViewModel>.Success(studentViewModel);
        }
        public IServiceResult<IEnumerable<StudentViewModel>> GetAll()
        {
            var students = _context.Students;
            var studentViewModels = students.Select(p => _mapper.Map<StudentViewModel>(p));

            return ServiceResult<IEnumerable<StudentViewModel>>.Success(studentViewModels);
        }
    }
}