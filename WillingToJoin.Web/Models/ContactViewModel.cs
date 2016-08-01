using System.ComponentModel.DataAnnotations;

namespace WillingToJoin.Web.Models
{
    public class ContactViewModel
    {
        public int ID { get; set; }
        public int? HouseholdID { get; set; }
        public int? AccountID { get; set; }
        public string ImportedID { get; set; }
        public string HouseholdImportedID { get; set; }
        public string AccountImportedID { get; set; }
      
        [Required(ErrorMessage = "First Name is required!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required!")]
        public string LastName { get; set; }
        public string Salutation { get; set; }
        public string Name { get; set; }
        public string MailingStreet { get; set; }
        public string MailingCity { get; set; }
        public string MailingState { get; set; }
        public string MailingPostalCode { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string Email { get; set; }
        public string OwnerID { get; set; }
        [Display(Name = "HomeEmail")]
        public string Npe01HomeEmail { get; set; }
        [Display(Name = "WorkEmail")]
        public string Npe01WorkEmail { get; set; }
        [Display(Name = "WorkPhone")]
        public string Npe01WorkPhone { get; set; }
        public int HouseholdFamilyRoleID { get; set; }

    }
}