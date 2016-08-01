using System.Data.Entity;
using System.Web;
using WillingToJoin.Shared.Context;
using WillingToJoin.Shared.Domain.Accounts;
using WillingToJoin.Shared.Services.Accounts;
using WillingToJoin.Shared.Utils;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WillingToJoin.Shared.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DatabaseContext context)
        {
            // Seed (Development Environment)
            if (ConfigUtil.IsDevelopment())
            {
	            AddAdmins(context);
	            AddHouseholdFamilyRole(context);
	            AddHouseholdStatus(context);
				AddAccountStatus(context);
				AddMailintListType(context);
			}
        }
		public void AddHouseholdStatus(DatabaseContext context)
		{
			//1=Active
			//2=Inactive
			//3=Bad Address
		}
		public void AddAccountStatus(DatabaseContext context)
		{
			//1=Active
			//2=Inactive
		}
		public void AddMailintListType(DatabaseContext context)
		{
			//1=Email
			//2=Snail Mail
		}

		public void AddHouseholdFamilyRole(DatabaseContext context)
	    {
			//1=Primary
			//2=Secondary
			//3=Child
	    }

	    public void AddAdmins(DatabaseContext context)
	    {
			// Admin Defaults
			const string username = "pwensel@hotmail.com";
			const string password = "123456";

			var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
			var roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(context));

			// Create Roles
			if (!roleManager.RoleExists("Admin")) roleManager.Create(new ApplicationRole() { Name = "Admin", Description = "Admin Role" });

			// Admin Account
			var admin = new ApplicationUser
			{
				UserName = username,
				FirstName = "Patrick",
				LastName = "Wensel",
				Email = username,
			};

			IAccountService accountService = new AccountService(context);

			var adminExists = accountService.FindByEmail(admin.UserName);
			if (adminExists != null) return;

			var adminresult = accountService.Create(admin, password);

			if (adminresult.Succeeded)
			{
				// Add Roles
				foreach (var identityRole in roleManager.Roles)
				{
					userManager.AddToRole(admin.Id, identityRole.Name);
				}
			}
		}
    }
}
