using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WillingToJoin.Areas.CRM2.Models
{
    public class HouseholdsNotesViewModel
    {
        public int HouseholdNoteID { get; set; }
        public int NoteTypeID { get; set; }
        public int HouseholdID { get; set; }
        public string Note { get; set; }
    }
}