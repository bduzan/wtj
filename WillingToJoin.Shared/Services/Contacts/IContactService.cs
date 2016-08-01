using System.Linq;
using WillingToJoin.Shared.Data;


namespace WillingToJoin.Shared.Services.Contacts
{
    public interface IContactService
    {
        IQueryable<Contact> GetAll();
        Contact Get(int id);
        Contact Add(Contact entity);
        Contact Update(Contact entity);
        void Delete(Contact entity);
    }
}
