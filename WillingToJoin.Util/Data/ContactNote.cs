//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WillingToJoin.Util.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ContactNote
    {
        public int ContactNoteID { get; set; }
        public int NoteTypeID { get; set; }
        public int ContactID { get; set; }
        public string Note { get; set; }
    
        public virtual Contact Contact { get; set; }
        public virtual NoteType NoteType { get; set; }
    }
}
