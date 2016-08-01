using System.Linq;
using WillingToJoin.Shared.Data;


namespace WillingToJoin.Shared.Services.Contacts
{
    public interface IDonationService
    {
        IQueryable<Transaction> GetAll();
        Transaction Get(int id);
        Transaction Add(Transaction entity);
        Transaction Update(Transaction entity);
        void Delete(Transaction entity);
    }
}
