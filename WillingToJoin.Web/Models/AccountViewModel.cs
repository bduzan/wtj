using System.ComponentModel.DataAnnotations;
namespace WillingToJoin.Web.Models
{
    public class AccountViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage="Imported ID is required!")]
        public string ImportedID { get; set; }
        [Required]
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
    }
}