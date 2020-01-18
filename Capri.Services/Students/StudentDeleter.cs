using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Capri.Database;
using Capri.Database.Entities;
using Capri.Services.Users;
using Capri.Web.ViewModels.Student;

namespace Capri.Services.Students
{
    public class StudentDeleter : IStudentDeleter
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStudentGetter _studentGetter;
        private readonly IUserDeleter _userDeleter;

        public StudentDeleter(
            ISqlDbContext context,
            IMapper mapper,
            IStudentGetter studentGetter,
            IUserDeleter userDeleter
            )
        {
            _context = context;
            _mapper = mapper;
            _studentGetter = studentGetter;
            _userDeleter = userDeleter;
        }

        public async Task<IServiceResult<StudentViewModel>> Delete(Guid id)
        {
            var student = 
                await _context
                .Students
                .FirstOrDefaultAsync(p => p.Id == id);

            if(student == null)
            {
                return ServiceResult<StudentViewModel>.Error(
                    $"Student with id {id} does not exist");
            }

            return await Delete(student);
        }

        public async Task<IServiceResult<StudentViewModel>> Delete(int indexNumber)
        {
            var student = 
                await _context
                .Students
                .FirstOrDefaultAsync(p => p.IndexNumber == indexNumber);

            if(student == null)
            {
                return ServiceResult<StudentViewModel>.Error(
                    $"Student with index number {indexNumber} does not exist");
            }

            return await Delete(student);
        }

        private async Task<IServiceResult<StudentViewModel>> Delete(Student student)
        {
            var studentViewModel = _mapper.Map<StudentViewModel>(student);

            var userResult = await _userDeleter.Delete(student.UserId);
            if(!userResult.Successful())
            {
                return ServiceResult<StudentViewModel>.Error(userResult.GetAggregatedErrors());
            }
            
            return ServiceResult<StudentViewModel>.Success(studentViewModel);
        }
    }
}