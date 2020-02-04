using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using PUT.WebServices.eKadryServiceClient;
using PUT.WebServices.eKontoServiceClient;
using EKontoUser = PUT.WebServices.eKontoServiceClient.eKontoService.User;
using EKontoUserSession = PUT.WebServices.eKontoServiceClient.eKontoService.UserSession;
using Capri.Database;
using Capri.Database.Entities.Identity;
using Capri.Services.Token;
using Capri.Web.ViewModels.User;

namespace Capri.Services.Account
{
    public class LoginService : ILoginService
    {
        private readonly IEKontoClient _eKontoClient;
        private readonly IEKadryClient _eKadryClient;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly ISqlDbContext _context;
        private readonly IMapper _mapper;

        private const int DidacticEmployeesEKontoGroupId = 85;
        private const string FacultyTypeName = "Wydział";

        const int FacultyWA = 265;
        const int FacultyWARiE = 1823;
        const int FacultyWIiT = 1824;
        const int FacultyWILiT = 1825;
        const int FacultyWIM = 1803;
        const int FacultyWIMiFT = 1826;
        const int FacultyWISiE = 1827;
        const int FacultyWIZ = 898;
        const int FacultyWTCh = 76;
        private static readonly Dictionary<int, int[]> DeaneryEKontoGroupIds = new Dictionary<int, int[]>
        {
            { 34, new int[1] { FacultyWA } },
            { 136, new int[1] { FacultyWARiE } },
            { 137, new int[1] { FacultyWIiT } },
            { 138, new int[1] { FacultyWILiT } },
            { 140, new int[1] { FacultyWIM } },
            { 139, new int[1] { FacultyWIMiFT } },
            { 141, new int[1] { FacultyWISiE } },
            { 42, new int[1] { FacultyWIZ } },
            { 36, new int[1] { FacultyWTCh } },
            { 79, new int[9] { FacultyWA, FacultyWARiE, FacultyWIiT, FacultyWILiT, FacultyWIM, FacultyWIMiFT, FacultyWISiE, FacultyWIZ, FacultyWTCh } }
        };

        public LoginService(
            IEKontoClient eKontoClient,
            IEKadryClient eKadryClient,
            SignInManager<User> signInManager, 
            UserManager<User> userManager,
            ITokenGenerator tokenGenerator,
            ISqlDbContext context,
            IMapper mapper)
        {
            _eKontoClient = eKontoClient;
            _eKadryClient = eKadryClient;
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
            _context = context;
            _mapper = mapper;
        }

        public async Task<IServiceResult<UserSecurityStamp>> Login(string sessionAuthorizationKey)
        {
            var eKontoUserSession = _eKontoClient.EndUserAuth(sessionAuthorizationKey);
            if(eKontoUserSession == null)
            {
                return ServiceResult<UserSecurityStamp>.Error(
                    "No eKonto user session found for the given session authorization key"
                );
            }
            var roles = GetRoles(eKontoUserSession);
            var roleNames = roles.Select(r => GetRoleName(r));
            var eKontoUser = eKontoUserSession.user;
            var user = _mapper.Map<User>(eKontoUser);
            var userExists = await _userManager.FindByEmailAsync(user.Email) != null;
            if(!userExists)
            {
                await _userManager.CreateAsync(user);
                await _userManager.AddToRolesAsync(user, roleNames);
            }
            else
            {
                await _userManager.UpdateAsync(user);
                var currentRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, currentRoles);
                await _userManager.AddToRolesAsync(user, roleNames);
            }
            await _context.SaveChangesAsync();
            await _signInManager.SignInAsync(user, false);

            var userRoleNames = await _userManager.GetRolesAsync(user);
            string token = _tokenGenerator.GenerateTokenFor(user, userRoleNames);
            user.SecurityStamp = token;
            
            return ServiceResult<UserSecurityStamp>.Success(new UserSecurityStamp
            {
                Email = user.Email,
                SecurityStamp = user.SecurityStamp
            });
        }

        private RoleType[] GetRoles(EKontoUserSession eKontoUserSession)
        {
            var roles = new RoleType[]{};
            if(IsDeanEmployee(eKontoUserSession))
            {
                roles.Append(RoleType.Dean);
            }
            else if(IsPromoter(eKontoUserSession.user))
            {
                roles.Append(RoleType.Promoter);
            }
            return roles;
        }

        private bool IsDeanEmployee(EKontoUserSession eKontoUserSession)
        {
            var userEKontoGroups = _eKontoClient.GetUserGroups(eKontoUserSession.identifier);
            foreach (var eKontoGroup in userEKontoGroups)
            {
                if (DeaneryEKontoGroupIds.ContainsKey(eKontoGroup.id))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsPromoter(EKontoUser user)
        {
            var employee = _eKadryClient.GetEmployeeDataById(int.Parse(user.internalId));
            return employee != null;
        }

        private string GetRoleName(RoleType role)
        {
            return Enum.GetName(typeof(RoleType), role);
        }
    } 
}
