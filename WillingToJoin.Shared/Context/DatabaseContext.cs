using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using WillingToJoin.Shared.Domain;
using WillingToJoin.Shared.Domain.Accounts;

namespace WillingToJoin.Shared.Context
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext()
            : base("name=umbracoDbDSN")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            BuildIdentity(modelBuilder);
            BuildImportedModels(modelBuilder);
            BuildInnerModels(modelBuilder);
        }

        private void BuildInnerModels(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<MailingListType>()
            //    .ToTable(string.Format("{0}s", typeof(MailingListType).Name));

            //modelBuilder.Entity<MailingList>()
            //    .ToTable(string.Format("{0}s", typeof(MailingList).Name));

            //modelBuilder.Entity<MailingListMember>()
            //    .ToTable(string.Format("{0}s", typeof(MailingListMember).Name));

            //modelBuilder.Entity<HouseholdFamilyRole>()
            //    .ToTable(string.Format("{0}s", typeof(HouseholdFamilyRole).Name));

            //modelBuilder.Entity<NoteType>()
            //    .ToTable(string.Format("{0}s", typeof(NoteType).Name));

            //modelBuilder.Entity<AccountNote>()
            //    .ToTable(string.Format("{0}s", typeof(AccountNote).Name));

            //modelBuilder.Entity<ContactNote>()
            //    .ToTable(string.Format("{0}s", typeof(ContactNote).Name));

            //modelBuilder.Entity<HouseholdNote>()
            //    .ToTable(string.Format("{0}s", typeof(HouseholdNote).Name));
        }

        private void BuildImportedModels(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Account>()
            //    .ToTable(string.Format("{0}s", typeof(Account).Name));

            //modelBuilder.Entity<Household>()
            //    .ToTable(string.Format("{0}s", typeof(Household).Name));

            //modelBuilder.Entity<Contact>()
            //    .ToTable(string.Format("{0}s", typeof(Contact).Name));
		}

        private void BuildIdentity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUser>()
                .ToTable("Users");

            modelBuilder.Entity<ApplicationUser>()
                .ToTable("Users");

            modelBuilder.Entity<IdentityUser>()
                .HasMany(u => u.Roles)
                .WithOptional()
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<IdentityUser>()
                .HasMany(u => u.Logins)
                .WithOptional()
                .HasForeignKey(l => l.UserId);

            modelBuilder.Entity<IdentityUser>()
                .HasMany(u => u.Claims)
                .WithOptional()
                .HasForeignKey(c => c.UserId);
        }

        public static DatabaseContext Create()
        {
            return new DatabaseContext();
        }
    }
}
