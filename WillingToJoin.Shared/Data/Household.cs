
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace WillingToJoin.Shared.Data
{

using System;
    using System.Collections.Generic;
    
public partial class Household
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Household()
    {

        this.Contacts = new HashSet<Contact>();

        this.HouseholdNotes = new HashSet<HouseholdNote>();

        this.Transactions = new HashSet<Transaction>();

    }


    public int ID { get; set; }

    public string ImportedID { get; set; }

    public string OwnerID { get; set; }

    public string Name { get; set; }

    public string Npo02FormulaMailingAddress { get; set; }

    public string Npo02HouseholdEmail { get; set; }

    public string Npo02HouseholdPhone { get; set; }

    public string Npo02MailingCity { get; set; }

    public string Npo02MailingPostalCode { get; set; }

    public string Npo02MailingState { get; set; }

    public string Npo02MailingStreet { get; set; }

    public string Npo02FormalGreeting { get; set; }

    public string Npo02InformalGreeting { get; set; }

    public string CvmReID { get; set; }

    public bool ExportedToCvm { get; set; }

    public string Note { get; set; }

    public string CvmFormalGreeting { get; set; }

    public string CvmInformalGreeting { get; set; }

    public string GroupSource { get; set; }

    public int HouseholdStatusID { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Contact> Contacts { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<HouseholdNote> HouseholdNotes { get; set; }

    public virtual HouseholdStatus HouseholdStatu { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Transaction> Transactions { get; set; }

}

}
