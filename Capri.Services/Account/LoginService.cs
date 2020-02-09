using System;
using System.Linq;
using System.Diagnostics;
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
using Capri.Services.Users;
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
        private readonly IUserGetter _userGetter;
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

        public EKontoUserSession mockPromoterUserSession = new EKontoUserSession {
                identifier = "1509",
                user = new EKontoUser {
                    loginName = "jerzy.nawrocki",
                    loginDomain = "put.poznan.pl",
                    name = "Jerzy",
                    surname = "Nawrocki",
                    passwordExpired = false,
                    internalId = "1509",
                    id = 1509,
                }
        };

        public EKontoUserSession mockDeanUserSession = new EKontoUserSession {
                identifier = "5061",
                user = new EKontoUser {
                    loginName = "katarzyna.malkowska",
                    loginDomain = "put.poznan.pl",
                    name = "Katarzyna",
                    surname = "Małkowska",
                    passwordExpired = false,
                    internalId = "5061",
                    id = 5061
                }
        };

        public LoginService(
            IEKontoClient eKontoClient,
            IEKadryClient eKadryClient,
            SignInManager<User> signInManager, 
            UserManager<User> userManager,
            IUserGetter userGetter,
            ITokenGenerator tokenGenerator,
            ISqlDbContext context,
            IMapper mapper)
        {
            _eKontoClient = eKontoClient;
            _eKadryClient = eKadryClient;
            _signInManager = signInManager;
            _userManager = userManager;
            _userGetter = userGetter;
            _tokenGenerator = tokenGenerator;
            _context = context;
            _mapper = mapper;
        }

        public async Task<IServiceResult<UserSecurityStamp>> Login(string sessionAuthorizationKey)
        {
            var eKontoUserSession = GetEKontoUserSessionFrom(sessionAuthorizationKey);
            if(eKontoUserSession == null)
            {
                return ServiceResult<UserSecurityStamp>.Error(
                    "Failed to get eKonto user session"
                );
            }

            var user = await CreateOrUpdateUserFrom(eKontoUserSession);
            await _signInManager.SignInAsync(user, true);

            return ServiceResult<UserSecurityStamp>.Success(new UserSecurityStamp
            {
                Email = user.Email,
                SecurityStamp = user.SecurityStamp
            });
        }

        private EKontoUserSession GetEKontoUserSessionFrom(string sessionAuthorizationKey)
        {
            try
            {
                return _eKontoClient.EndUserAuth(sessionAuthorizationKey);
            }
            catch
            {
                return null;
            }
        }

        private async Task<User> CreateOrUpdateUserFrom(EKontoUserSession eKontoUserSession)
        {
            var eKontoUser = eKontoUserSession.user;
            var roleNames = GetRoleNamesFor(eKontoUserSession);
            var existingUser = await _userManager.FindByIdAsync(eKontoUser.id.ToString());

            if(existingUser == null)
            {
                return await CreateUserFrom(eKontoUser, roleNames);
            }
            else
            {
                return await UpdateUser(existingUser, eKontoUser, roleNames);
            }
        }

        private async Task<User> CreateUserFrom(EKontoUser eKontoUser, IEnumerable<string> roleNames)
        {
            var user = new User();

            user = _mapper.Map(eKontoUser, user);
            user.Id = eKontoUser.id;
            user.SecurityStamp = "";

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            await _userManager.AddToRolesAsync(user, roleNames);
            await SetSecurityStampAsync(user, roleNames);

            return user;
        }

        private async Task<User> UpdateUser(User existingUser, EKontoUser eKontoUser, IEnumerable<string> roleNames)
        {
            var user = _mapper.Map(eKontoUser, existingUser);

            var currentRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRoles);
            await _userManager.AddToRolesAsync(user, roleNames);
            await _context.SaveChangesAsync();
            await SetSecurityStampAsync(user, roleNames);
            
            return user;
        }

        private async Task SetSecurityStampAsync(User user, IEnumerable<string> roleNames)
        {
            string token = _tokenGenerator.GenerateTokenFor(user, roleNames.ToArray());
            user.SecurityStamp = token;
            await _context.SaveChangesAsync();
        }

        private IEnumerable<string> GetRoleNamesFor(EKontoUserSession eKontoUserSession)
        {
            var roles = new List<string>();
            if(IsDeanEmployee(eKontoUserSession))
            {
                roles.Add("Dean");
            }
            else if(IsPromoter(eKontoUserSession.user))
            {
                roles.Add("Promoter");
            }
            return roles;
        }

        private bool IsDeanEmployee(EKontoUserSession eKontoUserSession)
        {
            if(eKontoUserSession.user.loginDomain != "put.poznan.pl")
            {
                return false;
            }
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
            if(user.loginDomain != "put.poznan.pl")
            {
                return false;
            }
            return _context.Promoters.Any(p => p.UserId == user.id);
        }
    } 
}
