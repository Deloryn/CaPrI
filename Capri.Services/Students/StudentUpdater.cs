using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Capri.Database;
using Capri.Database.Entities.Identity;
using Capri.Services.Users;
using Capri.Web.ViewModels.User;
using Capri.Web.ViewModels.Student;

namespace Capri.Services.Students
{
    public class StudentUpdater : IStudentUpdater
    {
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserUpdater _userUpdater;

        public StudentUpdater(
            ISqlDbContext context, 
            IMapper mapper,
            IUserUpdater userUpdater)
        {
            _context = context;
            _mapper = mapper;
            _userUpdater = userUpdater;
        }

        public async Task<IServiceResult<StudentViewModel>> Update(
            Guid id, 
            StudentRegistration newData)
        {
            var existingStudent = 
                await _context
                .Students
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existingStudent == null)
            {
                return ServiceResult<StudentViewModel>.Error(
                    $"Student with id {id} does not exist");
            }

            var credentials = new UserCredentials
            {
                Email = newData.Email,
                Password = newData.Password
            };

            var result = await _userUpdater.Update(
                existingStudent.UserId, 
                credentials,
                new string[] {
                    RoleType.Student
                });

            if (!result.Successful())
            {
                var errors = result.GetAggregatedErrors();
                return ServiceResult<StudentViewModel>.Error(errors);
            }
            
            existingStudent = _mapper.Map(newData, existingStudent);

            _context.Students.Update(existingStudent);
            await _context.SaveChangesAsync();

            var studentViewModel = _mapper.Map<StudentViewModel>(existingStudent);
            return ServiceResult<StudentViewModel>.Success(studentViewModel);
        }
    }
}