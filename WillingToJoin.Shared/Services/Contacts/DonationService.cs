using System.Linq;
using WillingToJoin.Shared.Data;

namespace WillingToJoin.Shared.Services.Contacts
{
    public class DonationService : IDonationService
    {

        private readonly WTJContext _store;


        public DonationService(WTJContext store)
        {
            _store = store;
        }

        public IQueryable<Transaction> GetAll()
        {
            return _store.Transactions;
        }

        public Transaction Get(int id)
        {
            return _store.Transactions.FirstOrDefault(f => f.ID == id);
        }

        public Transaction Add(Transaction entity)
        {
            return _store.Transactions.Add(entity);
        }

        public Transaction Update(Transaction entity)
        {
            _store.Transactions.Attach(entity);// Users.Attach(updatedUser);
            var entry = _store.Entry(entity);
            entry.Property(e => e.HouseholdID).IsModified = true;
            entry.Property(e => e.TransTypeID).IsModified = true;
            entry.Property(e => e.TransIncrID).IsModified = true;
            entry.Property(e => e.TransMethID).IsModified = true;
            entry.Property(e => e.Date).IsModified = true;
            entry.Property(e => e.Amount).IsModified = true;
            entry.Property(e => e.TransactionIncrement).IsModified = true;
            entry.Property(e => e.TransactionMethod).IsModified = true;
            entry.Property(e => e.TransactionType).IsModified = true;
            _store.SaveChanges();
            return entity;
        }

        public void Delete(Transaction entity)
        {
            _store.Transactions.Attach(entity);
            var entry = _store.Entry(entity);
            entry.State = System.Data.Entity.EntityState.Deleted;
            _store.SaveChanges();
        }
    }
}
