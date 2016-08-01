using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WillingToJoin.Areas.CRM2.Models
{
    public class HouseholdsViewModel
    {
        public int ID { get; set; }
        public string ImportedID { get; set; }
        public string OwnerID { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Html)]
        [AllowHtml]
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
        public int HouseholdStatusID { get; set; }
        public string GroupSource { get; set; }
    }
}