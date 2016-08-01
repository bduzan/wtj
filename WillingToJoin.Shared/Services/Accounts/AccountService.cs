using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Security;
using WillingToJoin.Shared.Context;
using WillingToJoin.Shared.Domain.Accounts;
using WillingToJoin.Shared.Gateways;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SendGrid;

namespace WillingToJoin.Shared.Services.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly UserStore<ApplicationUser> _userStore;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly ISendGridGateway _sendGridGateway;

        public AccountService(DatabaseContext databaseContext)
        {
            _sendGridGateway = new SendGridGateway();
            _userStore = new UserStore<ApplicationUser>(databaseContext);
            _userManager = new UserManager<ApplicationUser>(_userStore);
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(databaseContext));
        }

        public IEnumerable<ApplicationUser> Get()
        {
            return _userManager.Users.ToList();
        }

        public IEnumerable<string> GetRoles(string id)
        {
            return _userManager.GetRoles(id).ToList();
        }

        public IEnumerable<string> GetRoles()
        {
            return _roleManager.Roles.Select(role => role.Name).ToList();
        }

        public bool RoleExists(string name)
        {
            return _roleManager.RoleExists(name);
        }


        public bool CreateRole(string name)
        {
            IdentityResult idResult = _roleManager.Create(new IdentityRole(name));
            return idResult.Succeeded;
        }

        public bool IsInRole(string userId, string userRole)
        {
            return _userManager.IsInRole(userId, userRole);
        }

        public IEnumerable<ApplicationUser> GetUsersByRole(string userRole)
        {
            var userIds = _roleManager.FindByName(userRole).Users.Select(e => e.UserId).ToList();
            var users = _userManager.Users.Where(e => userIds.Contains(e.Id)).ToList();
            return users;
        }

        public void ClearUserRoles(string userId)
        {
            ApplicationUser user = _userManager.FindById(userId);
            var currentRoles = new List<IdentityUserRole>();

            currentRoles.AddRange(user.Roles);

            foreach (var currentRole in currentRoles)
            {
                var role = _roleManager.Roles.FirstOrDefault(x => x.Id == currentRole.RoleId);
                _userManager.RemoveFromRole(userId, role.Name);
            }

        }

        public void SendAccountInformation(ApplicationUser user, string password)
        {
            var email = user.Email;
            var mail = new SendGridMessage
            {
                Subject = "Audtion Room: Your Account",
                Html = @"<p>Hello " + user.FirstName + ", "
                + "<br /><br />"
                + "Thank you for signing up with us. We pride ourselves in providing quality service for all your gift card needs. "
                + "The following account has been registered on our system with your email address.<br /><br />"
                + "To login, please use the password provided to you below. Once logged in, you can change your password under the account profile.<br />"
                + "<br /><br />"
                + "Username: <strong>" + user.UserName + "</strong><br />"
                + "Password: <strong>" + password + "</strong><br />"
                + "<br /><br />"
                + "<p>Thank You, <br />Audtion Room</p>",
            };

            mail.AddTo(email);
            _sendGridGateway.Send(mail);
        }

        public ApplicationUser Find(string username, string password)
        {
            return _userManager.Find(username, password);
        }

        public ApplicationUser Find(UserLoginInfo loginInfo)
        {
            return _userManager.Find(loginInfo);
        }

        public IdentityResult AddLogin(string userId, UserLoginInfo loginInfo)
        {
            return _userManager.AddLogin(userId, loginInfo);
        }

        public IList<UserLoginInfo> GetLogins(string userId)
        {
            return _userManager.GetLogins(userId);
        }

        public IdentityResult Create(ApplicationUser user, string password)
        {
            return _userManager.Create(user, password);
        }
        public IdentityResult Create(ApplicationUser user)
        {
            var password = Membership.GeneratePassword(12, 1);
            return _userManager.Create(user, password);
        }

        public void Update(ApplicationUser user)
        {
            _userManager.Update(user);

            var context = _userStore.Context;
            context.SaveChanges();
        }

        public IdentityResult AddToRole(string userId, string role)
        {
            try
            {
                _userManager.AddToRole(userId, role);
            }
            catch (Exception exception)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(exception);
            }

            return new IdentityResult();
        }

        public ApplicationUser FindById(string userId)
        {
            return _userManager.FindById(userId);
        }

        public ApplicationUser FindByName(string userName)
        {
            return _userManager.FindByName(userName);
        }

        public ApplicationUser FindByEmail(string emailAddress)
        {
            return _userManager.FindByEmail(emailAddress);
        }

        public IdentityResult RemoveLogin(string userId, UserLoginInfo userLoginInfo)
        {
            return _userManager.RemoveLogin(userId, userLoginInfo);
        }

        public IdentityResult ChangePassword(string userId, string oldPassword, string newPassword)
        {
            return _userManager.ChangePassword(userId, oldPassword, newPassword);
        }

        public IdentityResult AddPassword(string userId, string password)
        {
            return _userManager.AddPassword(userId, password);
        }

        public IdentityResult RemovePassword(string userId)
        {
            return _userManager.RemovePassword(userId);
        }

        public IdentityResult SetPassword(string userId)
        {
            try
            {
                var password = Membership.GeneratePassword(12, 1);
                _userManager.AddPassword(userId, password);

                var user = _userManager.FindById(userId);
                SendAccountInformation(user, password);
            }
            catch (Exception exception)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(exception);
            }

            return new IdentityResult();
        }

        public IdentityResult SetPassword(string userId, string password)
        {
            try
            {
                _userManager.AddPassword(userId, password);

                var user = _userManager.FindById(userId);
                SendAccountInformation(user, password);
            }
            catch (Exception exception)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(exception);
            }

            return new IdentityResult();
        }

        public ClaimsIdentity CreateIdentity(ApplicationUser user, string authenticationType)
        {
            return _userManager.CreateIdentity(user, authenticationType);
        }

        public void ResetAccount(string userId)
        {
            var password = Membership.GeneratePassword(12, 1);

            try
            {
                _userManager.RemovePassword(userId);
                _userManager.AddPassword(userId, password);

                var user = _userManager.FindById(userId);
                SendAccountInformation(user, password);
            }
            catch (Exception exception)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(exception);
            }
        }
    }
}
