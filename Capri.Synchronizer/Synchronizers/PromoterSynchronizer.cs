using Capri.Database;
using PUT.WebServices.eKontoServiceClient;
using PUT.WebServices.eKadryServiceClient;
using EKontoUser = PUT.WebServices.eKontoServiceClient.eKontoService.User;
using EKadryEmployee = PUT.WebServices.eKadryServiceClient.eKadryService.Employee;
using EKadryDepartment = PUT.WebServices.eKadryServiceClient.eKadryService.Department;
using EKadryEmployment = PUT.WebServices.eKadryServiceClient.eKadryService.Employment;
using Capri.Database.Entities;
using Capri.Synchronizer.Synchronizers;
using AutoMapper;
using System.Linq;
using Capri.Database.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Capri.Synchronizer
{
    public class PromoterSynchronizer : IPromoterSynchronizer
    {
        // TODO make that const configurable in application 
        private const int DidacticEmployeesEKontoGroupId = 85;
        private const string FacultyTypeName = "Wydział";
        private const string InstituteTypeName = "Instytut";

        private readonly IEKontoClient _eKontoClient;
        private readonly IEKadryClient _eKadryClient;
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;

        public PromoterSynchronizer(
            IEKontoClient eKontoClient,
            IEKadryClient eKadryClient,
            ISqlDbContext context,
            IMapper mapper)
        {
            _eKontoClient = eKontoClient;
            _eKadryClient = eKadryClient;
            _context = context;
            _mapper = mapper;
        }

        public void Synchronize()
        {
            EKontoUser[] didacticEKontoUsers = _eKontoClient.GetAllUsersByIds(_eKontoClient.GetGroupUsers(DidacticEmployeesEKontoGroupId));

            foreach (EKontoUser didacticUser in didacticEKontoUsers)
            {
                EKadryEmployee employee = _eKadryClient.GetEmployeeDataById(int.Parse(didacticUser.internalId));
                if (employee == null)
                {
                    continue;
                }

                EKadryDepartment facultyDepartment = getFacultyDepartment(employee, out EKadryDepartment instituteDepartment);
                if (facultyDepartment == null)
                {
                    continue;
                }

                //Faculty faculty = _context.Faculties.Where(f => f.Id == facultyDepartment.id).FirstOrDefault();
                Institute institute = _context.Institutes.Where(i => i.Id == instituteDepartment.id).FirstOrDefault();

                insertOrUpdateEmployee(didacticUser, employee, institute);
            }
        }

        private void insertOrUpdateEmployee(EKontoUser eKontoUser, EKadryEmployee eKadryEmployee, Institute institute)
        {
            Promoter promoter = _context.Promoters.Where(p => p.Id == eKadryEmployee.id).FirstOrDefault();

            if (promoter == null)
            {
                // TODO later something about creating user in database
                var user = new User
                {
                    UserName = eKontoUser.GetLogin(),
                    NormalizedUserName =
                    new UpperInvariantLookupNormalizer()
                        .Normalize(eKontoUser.GetLogin())
                        .ToUpperInvariant(),
                    Email = eKontoUser.GetLogin(),
                    NormalizedEmail =
                    new UpperInvariantLookupNormalizer()
                        .Normalize(eKontoUser.GetLogin())
                        .ToUpperInvariant(),
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<User>().HashPassword(null, "zaq1@WSX"),
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                promoter = new Promoter
                {
                    Id = eKadryEmployee.id,
                    InstituteId = institute.Id,
                    ExpectedNumberOfBachelorProposals = 0,
                    ExpectedNumberOfMasterProposals = 0,
                    UserId = user.Id
                };
                _mapper.Map(eKontoUser, promoter);
                _mapper.Map(eKadryEmployee, promoter);
                if (promoter.TitlePrefix == null)
                {
                    promoter.TitlePrefix = "";
                }

                _context.Promoters.Add(promoter);
            }
            else
            {
                _mapper.Map(eKontoUser, promoter);
                _mapper.Map(eKadryEmployee, promoter);
                promoter.InstituteId = institute.Id;
                if (promoter.TitlePrefix == null)
                {
                    promoter.TitlePrefix = "";
                }

                _context.Promoters.Update(promoter);
                
            }
            _context.SaveChanges();
        }

        private EKadryDepartment getFacultyDepartment(EKadryEmployee employee, out EKadryDepartment instituteDepartment)
        {
            instituteDepartment = null;

            if (employee.employments == null)
            {
                return null;
            }

            foreach (EKadryEmployment employment in employee.employments)
            {
                if (employment.isActive == false)
                {
                    continue;
                }

                if (employment.position == null)
                {
                    continue;
                }

                if (employment.position.isEducational == false)
                {
                    continue;
                }

                EKadryDepartment department = employment.position.department;
                while (department != null)
                {
                    if (department.typeName == InstituteTypeName)
                    {
                        instituteDepartment = department;
                    }

                    if (department.typeName == FacultyTypeName)
                    {
                        return department;
                    }

                    department = department.parentDepartment;
                }
            }

            return null;
        }

    }
}
