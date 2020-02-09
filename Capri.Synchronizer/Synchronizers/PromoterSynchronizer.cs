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
                if(employee == null || employee.title == null)
                {
                    continue;
                }

                EKadryDepartment facultyDepartment = getFacultyDepartment(employee, out EKadryDepartment instituteDepartment);
                if (facultyDepartment == null)
                {
                    continue;
                }

                Institute institute = _context.Institutes.Where(i => i.Id == instituteDepartment.id).FirstOrDefault();
                
                AddOrUpdatePromoterUser(didacticUser);
                AddOrUpdateEmployee(didacticUser, employee, institute);
            }
        }

        private void AddOrUpdatePromoterUser(EKontoUser eKontoUser)
        {
            var role = _context.Roles.FirstOrDefault(r => r.Name == "Promoter");
            var existingUser = _context.Users.FirstOrDefault(u => u.Id == eKontoUser.id);
            if(existingUser == null)
            {
                var user = new User();
                user = _mapper.Map(eKontoUser, user);
                user.Id = eKontoUser.id;
                user.SecurityStamp = "";
                _context.Users.Add(user);
                _context.UserRoles.Add(new IntUserRole {
                    UserId = eKontoUser.id,
                    RoleId = role.Id
                });
            }
            else
            {
                var user = _mapper.Map(eKontoUser, existingUser);
                _context.Users.Update(user);
                var userRoles = _context.UserRoles.Where(r => r.UserId == eKontoUser.id);
                _context.UserRoles.RemoveRange(userRoles);
                _context.SaveChanges();
                _context.UserRoles.Add(new IntUserRole {
                    UserId = eKontoUser.id,
                    RoleId = role.Id
                });
            }
            _context.SaveChanges();
        }

        private void AddOrUpdateEmployee(EKontoUser eKontoUser, EKadryEmployee eKadryEmployee, Institute institute)
        {
            Promoter promoter = _context.Promoters.Where(p => p.Id == eKadryEmployee.id).FirstOrDefault();

            if(promoter == null)
            {
                promoter = new Promoter
                {
                    Id = eKadryEmployee.id,
                    InstituteId = institute.Id,
                    ExpectedNumberOfBachelorProposals = 0,
                    ExpectedNumberOfMasterProposals = 0,
                    UserId = eKontoUser.id
                };
                _mapper.Map(eKontoUser, promoter);
                _mapper.Map(eKadryEmployee, promoter);
                _context.Promoters.Add(promoter);
            }
            else
            {
                _mapper.Map(eKontoUser, promoter);
                _mapper.Map(eKadryEmployee, promoter);
                promoter.InstituteId = institute.Id;
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
