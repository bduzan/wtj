using System.Linq;
using WillingToJoin.Shared.Data;

namespace WillingToJoin.Shared.Services.Contacts
{
    public interface IHouseholdNoteService
    {
        IQueryable<HouseholdNote> GetAll();
        HouseholdNote Get(int id);
        HouseholdNote Add(HouseholdNote entity);
        //HouseholdNote Update(HouseholdNote entity);
        //void Delete(HouseholdNote entity);
    }
}
