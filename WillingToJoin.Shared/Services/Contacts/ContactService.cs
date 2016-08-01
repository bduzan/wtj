using System.Linq;
using WillingToJoin.Shared.Data;


namespace WillingToJoin.Shared.Services.Contacts
{
    public class ContactService : IContactService
    {
		private readonly WTJContext _store;

		public ContactService(WTJContext store)
        {
            _store = store;
        }

        public IQueryable<Contact> GetAll()
        {
            return _store.Contacts;
        }

        public Contact Get(int id)
        {
			return _store.Contacts.FirstOrDefault(f => f.ID == id);
		}

        public Contact Add(Contact entity)
        {
			_store.Contacts.Add(entity);
            _store.SaveChanges();
            return entity;
		}

        public Contact Update(Contact entity)
        {
            _store.Contacts.Attach(entity);// Users.Attach(updatedUser);
            var entry = _store.Entry(entity);

            //var entry = _store.Entry(entity);
            //entry.State = System.Data.Entity.EntityState.Modified;
            //_store.Contacts.Attach(entity);// Users.Attach(updatedUser);
            //var entry = _store.Entry(entity);
            entry.Property(e => e.HouseholdID).IsModified = true;
			entry.Property(e => e.AccountID).IsModified = true;
			entry.Property(e => e.LastName).IsModified = true;
			entry.Property(e => e.FirstName).IsModified = true;
			entry.Property(e => e.Salutation).IsModified = true;
			entry.Property(e => e.Name).IsModified = true;
			entry.Property(e => e.MailingStreet).IsModified = true;
			entry.Property(e => e.MailingCity).IsModified = true;
			entry.Property(e => e.MailingState).IsModified = true;
			entry.Property(e => e.MailingPostalCode).IsModified = true;
			entry.Property(e => e.Phone).IsModified = true;
			entry.Property(e => e.MobilePhone).IsModified = true;
			entry.Property(e => e.HomePhone).IsModified = true;
			entry.Property(e => e.Email).IsModified = true;
			entry.Property(e => e.HomeEmail).IsModified = true;
			entry.Property(e => e.WorkEmail).IsModified = true;
			entry.Property(e => e.WorkPhone).IsModified = true;
			entry.Property(e => e.HouseholdFamilyRoleID).IsModified = true;
			entry.Property(e => e.ContactStatusID).IsModified = true;
			_store.SaveChanges();
			return entity;
		}

        public void Delete(Contact entity)
        {
			_store.Contacts.Attach(entity);
			var entry = _store.Entry(entity);
			entry.State = System.Data.Entity.EntityState.Deleted;
			_store.SaveChanges();
		}
    }
}
