
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
    
public partial class Account
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Account()
    {

        this.AccountNotes = new HashSet<AccountNote>();

        this.Contacts = new HashSet<Contact>();

    }


    public int ID { get; set; }

    public string ImportedID { get; set; }

    public string Name { get; set; }

    public string Type { get; set; }

    public string BillingStreet { get; set; }

    public string BillingCity { get; set; }

    public string BillingState { get; set; }

    public string BillingPostalCode { get; set; }

    public string ShippingStreet { get; set; }

    public string ShippingCity { get; set; }

    public string ShippingState { get; set; }

    public string ShippingPostalCode { get; set; }

    public string Phone { get; set; }

    public string Website { get; set; }

    public string Facebook { get; set; }

    public string SourceGroup { get; set; }

    public int AccountStatusID { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<AccountNote> AccountNotes { get; set; }

    public virtual AccountStatus AccountStatu { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Contact> Contacts { get; set; }

}

}
