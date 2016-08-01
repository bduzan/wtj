using System.ComponentModel.DataAnnotations;

namespace WillingToJoin.Areas.CRM2.Models
{
    public class ContactsViewModel
    {
        public int ID { get; set; }
        public int? HouseholdID { get; set; }
        public int? AccountID { get; set; }
        public string ImportedID { get; set; }
        public string HouseholdImportedID { get; set; }
        public string AccountImportedID { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        public string Salutation { get; set; }
        public string Name { get; set; }
        [Display(Name = "Street")]
        public string MailingStreet { get; set; }
        [Display(Name = "City")]
        public string MailingCity { get; set; }
        [Display(Name = "State")]
        public string MailingState { get; set; }
        [Display(Name = "Postal Code")]
        public string MailingPostalCode { get; set; }
        public string Phone { get; set; }
        [Display(Name = "Mobile Phone")]
        public string MobilePhone { get; set; }
        [Display(Name = "Home Phone")]
        public string HomePhone { get; set; }
        public string Email { get; set; }
        public string OwnerID { get; set; }
        [Display(Name = "Home Email")]
        public string Npe01HomeEmail { get; set; }
        [Display(Name = "Work Email")]
        public string Npe01WorkEmail { get; set; }
        [Display(Name = "Work Phone")]
        public string Npe01WorkPhone { get; set; }
        public int HouseholdFamilyRoleID { get; set; }
        public int ContactStatusID { get; set; }
    }
}