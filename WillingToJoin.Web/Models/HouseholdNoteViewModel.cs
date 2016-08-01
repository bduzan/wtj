using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WillingToJoin.Web.Models
{
    public class HouseholdNoteViewModel
    {
        public int HouseholdNoteID { get; set; }
        public int NoteTypeID { get; set; }
        public int HouseholdID { get; set; }
        public string Note { get; set; }
    }
}