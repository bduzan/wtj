using System.Collections.Generic;
using System.Security.Claims;
using WillingToJoin.Shared.Domain.Accounts;
using Microsoft.AspNet.Identity;

namespace WillingToJoin.Shared.Services.Accounts
{
    public interface IAccountService
    {
        IEnumerable<ApplicationUser> Get();
        IEnumerable<string> GetRoles(string id);
        IEnumerable<string> GetRoles();
        bool RoleExists(string name);
        bool CreateRole(string name);
        bool IsInRole(string userId, string userRole);
        IEnumerable<ApplicationUser> GetUsersByRole(string userRole);
        void ClearUserRoles(string userId);
        ApplicationUser Find(string username, string password);
        ApplicationUser Find(UserLoginInfo loginInfo);
        IdentityResult AddLogin(string userId, UserLoginInfo loginInfo);
        IList<UserLoginInfo> GetLogins(string userId);
        IdentityResult Create(ApplicationUser user, string password);
        IdentityResult Create(ApplicationUser user);
        void Update(ApplicationUser user);
        IdentityResult AddToRole(string userId, string role);
        ApplicationUser FindById(string userId);
        ApplicationUser FindByName(string userName);
        ApplicationUser FindByEmail(string emailAddress);
        IdentityResult RemoveLogin(string userId, UserLoginInfo userLoginInfo);
        IdentityResult ChangePassword(string userId, string oldPassword, string newPassword);
        IdentityResult AddPassword(string userId, string password);
        IdentityResult RemovePassword(string userId);
        IdentityResult SetPassword(string userId);
        IdentityResult SetPassword(string userId, string password);
        ClaimsIdentity CreateIdentity(ApplicationUser user, string authenticationType);
        void ResetAccount(string userId);
    }
}