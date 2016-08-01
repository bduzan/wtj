using System.Linq;
using WillingToJoin.Shared.Context;
using WillingToJoin.Shared.Data;
using WillingToJoin.Shared.Domain;

namespace WillingToJoin.Shared.Services.Contacts
{
    public class AccountService : IAccountService
    {
		private readonly WTJContext _store;

		public AccountService(WTJContext store)
        {
            _store = store;
        }

        public IQueryable<Account> GetAll()
        {
			return _store.Accounts;
		}

        public Account Get(int id)
        {
			return _store.Accounts.FirstOrDefault(f => f.ID == id);
		}

        public Account Add(Account entity)
        {
			return _store.Accounts.Add(entity);
		}

        public Account Update(Account entity)
        {
			_store.Accounts.Attach(entity);// Users.Attach(updatedUser);
			var entry = _store.Entry(entity);
			entry.Property(e => e.Name).IsModified = true;
			entry.Property(e => e.Type).IsModified = true;
			entry.Property(e => e.BillingStreet).IsModified = true;
			entry.Property(e => e.BillingCity).IsModified = true;
			entry.Property(e => e.BillingState).IsModified = true;
			entry.Property(e => e.BillingPostalCode).IsModified = true;
			entry.Property(e => e.ShippingStreet).IsModified = true;
			entry.Property(e => e.ShippingCity).IsModified = true;
			entry.Property(e => e.ShippingState).IsModified = true;
			entry.Property(e => e.ShippingPostalCode).IsModified = true;
			entry.Property(e => e.Phone).IsModified = true;
			entry.Property(e => e.Website).IsModified = true;
			entry.Property(e => e.Facebook).IsModified = true;
			entry.Property(e => e.SourceGroup).IsModified = true;
			entry.Property(e => e.AccountStatusID).IsModified = true;
			_store.SaveChanges();
			return entity;
		}

        public void Delete(Account entity)
        {
			_store.Accounts.Attach(entity);
			var entry = _store.Entry(entity);
			entry.State = System.Data.Entity.EntityState.Deleted;
			_store.SaveChanges();
		}
    }
}
