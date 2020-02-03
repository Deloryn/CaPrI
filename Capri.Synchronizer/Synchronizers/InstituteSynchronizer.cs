using System.Linq;
using System;
using AutoMapper;
using PUT.WebServices.eKadryServiceClient;
using DepartmentTreeElement = PUT.WebServices.eKadryServiceClient.eKadryService.DepartmentTreeElement;
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

        public void Synchronize() {
            var rectorDepartmentId = 1174;
            DepartmentTreeElement departmentTreeRoot = _eKadryClient.GetDepartmentsTree(rectorDepartmentId);
            var instituteDepartments = departmentTreeRoot
                .subdepartments
                .Where(subTreeRoot => subTreeRoot.department.name.StartsWith("Wydział"))
                .SelectMany(subTreeRoot => subTreeRoot.subdepartments)
                .Where(subTreeRoot => subTreeRoot.department.name.StartsWith("Instytut"))
                .Select(subTreeRoot => subTreeRoot.department);

            foreach(var instituteDepartment in instituteDepartments)
            {
                var institute = _mapper.Map<Institute>(instituteDepartment);
                _context.Institutes.Add(institute);
            }
            _context.SaveChanges();
        }
    }
}