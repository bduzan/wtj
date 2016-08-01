namespace WillingToJoin.Areas.CRM.Models
{
    public class AccountViewModel
    {
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
    }
}