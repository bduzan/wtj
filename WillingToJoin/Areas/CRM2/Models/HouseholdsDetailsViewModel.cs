using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WillingToJoin.Areas.CRM2.Models
{
    public class HouseholdsDetailsViewModel
    {
        public int ID { get; set; }
        public string ImportedID { get; set; }
        public string OwnerID { get; set; }
        [DisplayName("Household Name")]
        public string Name { get; set; }
        [DataType(DataType.Html)]
        [AllowHtml]
        [DisplayName("Mailing Address")]
        public string Npo02FormulaMailingAddress { get; set; }
        public string Npo02HouseholdEmail { get; set; }
        public string Npo02HouseholdPhone { get; set; }
        public string Npo02MailingCity { get; set; }
        [DisplayName("Postal Code")]
        public string Npo02MailingPostalCode { get; set; }
        [DisplayName("State")]
        public string Npo02MailingState { get; set; }
        public string Npo02MailingStreet { get; set; }
        [DisplayName("Formal Greeting")]
        public string Npo02FormalGreeting { get; set; }
        [DisplayName("Informal Greeting")]
        public string Npo02InformalGreeting { get; set; }
        [DisplayName("CVM Re ID")]
        public string CvmReID { get; set; }
        public bool ExportedToCvm { get; set; }
        public string Note { get; set; }
        [DisplayName("CVM Formal Greeting")]
        public string CvmFormalGreeting { get; set; }
        [DisplayName("CVM Informal Greeting")]
        public string CvmInformalGreeting { get; set; }
        public int HouseholdStatusID { get; set; }
        public string GroupSource { get; set; }
        
    
    }
}