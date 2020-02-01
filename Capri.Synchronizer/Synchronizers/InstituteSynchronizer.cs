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
            DepartmentTreeElement element = _eKadryClient.GetDepartmentsTree(null);
            foreach(var department in element.subdepartments) {
                var institute = _mapper.Map<Institute>(department);
                _context.Institutes.Update(institute);
            }
        }
    }
}