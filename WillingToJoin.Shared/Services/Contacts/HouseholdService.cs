using System.Linq;
using WillingToJoin.Shared.Context;
using WillingToJoin.Shared.Data;
using Household = WillingToJoin.Shared.Data.Household;

namespace WillingToJoin.Shared.Services.Contacts
{
    public class HouseholdService : IHouseholdService
    {

	    private readonly WTJContext _store;  


        public HouseholdService(WTJContext store)
        {
            _store = store;
        }

        public IQueryable<Household> GetAll()
        {
	        return _store.Households;
        }

        public Household Get(int id)
        {
            return _store.Households.FirstOrDefault(f => f.ID == id);
        }

        public Household Add(Household entity)
        {
            return _store.Households.Add(entity);
        }

        public Household Update(Household entity)
        {
	        _store.Households.Attach(entity);// Users.Attach(updatedUser);
	        var entry = _store.Entry(entity);
	        entry.Property(e => e.Name).IsModified = true;
			entry.Property(e => e.Npo02FormulaMailingAddress).IsModified = true;
			entry.Property(e => e.Npo02HouseholdEmail).IsModified = true;
			entry.Property(e => e.Npo02HouseholdPhone).IsModified = true;
			entry.Property(e => e.Npo02MailingCity).IsModified = true;
			entry.Property(e => e.Npo02MailingPostalCode).IsModified = true;
			entry.Property(e => e.Npo02MailingState).IsModified = true;
			entry.Property(e => e.Npo02MailingStreet).IsModified = true;
			entry.Property(e => e.Npo02FormalGreeting).IsModified = true;
			entry.Property(e => e.Npo02InformalGreeting).IsModified = true;
			entry.Property(e => e.CvmReID).IsModified = true;
			entry.Property(e => e.ExportedToCvm).IsModified = true;
			entry.Property(e => e.Note).IsModified = true;
			entry.Property(e => e.CvmFormalGreeting).IsModified = true;
			entry.Property(e => e.CvmInformalGreeting).IsModified = true;
			entry.Property(e => e.GroupSource).IsModified = true;
			entry.Property(e => e.HouseholdStatusID).IsModified = true;
			_store.SaveChanges();
	        return entity;
        }

        public void Delete(Household entity)
        {
			_store.Households.Attach(entity);
			var entry = _store.Entry(entity);
			entry.State = System.Data.Entity.EntityState.Deleted;
			_store.SaveChanges();
		}
    }
}
