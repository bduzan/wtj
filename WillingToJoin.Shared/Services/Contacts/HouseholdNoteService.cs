using System.Linq;
using WillingToJoin.Shared.Data;

namespace WillingToJoin.Shared.Services.Contacts
{
    public class HouseholdNoteService : IHouseholdNoteService
    {

        private readonly WTJContext _store;


        public HouseholdNoteService(WTJContext store)
        {
            _store = store;
        }

        public IQueryable<HouseholdNote> GetAll()
        {
            return _store.HouseholdNotes;
        }

        public HouseholdNote Get(int id)
        {
            return _store.HouseholdNotes.FirstOrDefault(f => f.HouseholdID == id);
        }

        public HouseholdNote Add(HouseholdNote entity)
        {
            _store.HouseholdNotes.Add(entity);
            _store.SaveChanges();
            return entity;
        }
    

        //public HouseholdNote Update(HouseholdNote entity)
        //{
        //    _store.HouseholdNotes.Attach(entity);// Users.Attach(updatedUser);
        //    var entry = _store.Entry(entity);
        //    entry.Property(e => e.NoteTypeID).IsModified = true;
        //    entry.Property(e => e.HouseholdID).IsModified = true;
        //    entry.Property(e => e.Note).IsModified = true;
        //    _store.SaveChanges();
        //    return entity;
        //}

        //public void Delete(HouseholdNote entity)
        //{
        //    _store.HouseholdNotes.Attach(entity);
        //    var entry = _store.Entry(entity);
        //    entry.State = System.Data.Entity.EntityState.Deleted;
        //    _store.SaveChanges();
        //}
    }
}
