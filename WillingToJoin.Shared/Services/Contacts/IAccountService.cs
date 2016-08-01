using System.Linq;
using WillingToJoin.Shared.Data;


namespace WillingToJoin.Shared.Services.Contacts
{
    public interface IAccountService
    {
        IQueryable<Account> GetAll();
        Account Get(int id);
        Account Add(Account entity);
        Account Update(Account entity);
        void Delete(Account entity);
    }
}
