using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PUT.WebServices.eKadryServiceClient;
using Department = PUT.WebServices.eKadryServiceClient.eKadryService.Department;
using Capri.Database;
using Capri.Database.Entities;

namespace Capri.Synchronizer.Synchronizers
{
    public class InstituteSynchronizer : IInstituteSynchronizer
    {
        private readonly IEKadryClient _eKadryClient;
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;

        public InstituteSynchronizer(
            IEKadryClient eKadryClient,
            ISqlDbContext context,
            IMapper mapper
        )
        {
            _eKadryClient = eKadryClient;
            _context = context;
            _mapper = mapper;
        }

        public void Synchronize() 
        {
            var instituteDepartments = getInstituteDepartments();
            foreach(var instituteDepartment in instituteDepartments)
            {
                var institute = _mapper.Map<Institute>(instituteDepartment);
                AddOrUpdate(institute);
            }
            _context.SaveChanges();
        }

        private IEnumerable<Department> getInstituteDepartments()
        {
            var rectorDepartmentId = 1174;
            var departmentTreeRoot = _eKadryClient.GetDepartmentsTree(rectorDepartmentId);
            return departmentTreeRoot
                .subdepartments
                .Where(subTreeRoot => subTreeRoot.department.name.StartsWith("Wydział"))
                .SelectMany(subTreeRoot => subTreeRoot.subdepartments)
                .Where(subTreeRoot => subTreeRoot.department.name.StartsWith("Instytut"))
                .Select(subTreeRoot => subTreeRoot.department);
        }

        private void AddOrUpdate(Institute institute)
        {
            if(_context.Institutes.Any(i => i.Id == institute.Id))
            {
                _context.Institutes.Update(institute);
            }
            else
            {
                _context.Institutes.Add(institute);
            }
        }
    }
}