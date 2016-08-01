using System.Linq;
using WillingToJoin.Shared.Data;


namespace WillingToJoin.Shared.Services.Contacts
{
    public interface IHouseholdService
    {
        IQueryable<Household> GetAll();
        Household Get(int id);
        Household Add(Household entity);
        Household Update(Household entity);
        void Delete(Household entity);
    }
}
