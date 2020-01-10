using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Capri.Database;

namespace Capri.Services.Students
{
    public class StudentGroupValidator : IStudentGroupValidator
    {
        private readonly ISqlDbContext _context;
        private readonly IStudentGetter _studentGetter;

        public StudentGroupValidator(
            ISqlDbContext context,
            IStudentGetter studentGetter
        )
        {
            _context = context;
            _studentGetter = studentGetter;
        }

        public async Task<IServiceResult<bool>> DoStudentsExist(IEnumerable<Guid> studentIds)
        {
            foreach(var id in studentIds)
            {
                var result = await _studentGetter.Get(id);
                if(!result.Successful())
                {
                    return ServiceResult<bool>.Success(false);
                }
            }
            return ServiceResult<bool>.Success(true);
        }
    }
}