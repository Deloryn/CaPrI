using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Capri.Database.Entities;
using Capri.Web.ViewModels.Student;

namespace Capri.Services.Students
{
    public interface IStudentGetter
    {
        Task<IServiceResult<StudentViewModel>> Get(Guid id);
        Task<IServiceResult<StudentViewModel>> Get(int indexNumber);
        Task<IServiceResult<ICollection<Student>>> GetMany(IEnumerable<int> indexNumbers);
        IServiceResult<IEnumerable<StudentViewModel>> GetAll();
    }
}