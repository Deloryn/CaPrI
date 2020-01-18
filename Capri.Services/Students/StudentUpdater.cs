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
            if(newData.ProposalId != null)
            {
                var proposal = await _context.Proposals.FirstOrDefaultAsync(p => p.Id == newData.ProposalId);
                if(proposal == null)
                {
                    return ServiceResult<StudentViewModel>.Error(
                        $"The proposal with id {newData.ProposalId} does not exist"
                    );
                }
            }

            var isIndexNumberTaken = await IsIndexNumberTaken(id, newData.IndexNumber);
            if(isIndexNumberTaken)
            {
                return ServiceResult<StudentViewModel>.Error(
                    $"Index number {newData.IndexNumber} is already taken"
                );
            }

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
                new RoleType[] {
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

        private async Task<bool> IsIndexNumberTaken(Guid myId, int newIndexNumber)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.IndexNumber == newIndexNumber);
            if(student == null)
            {
                return false;
            }
            else if(student.Id == myId)
            {
                return false;
            }
            return true;
        }
    }
}