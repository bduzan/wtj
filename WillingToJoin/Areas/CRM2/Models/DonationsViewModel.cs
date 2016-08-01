using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WillingToJoin.Shared.Data;
	
namespace WillingToJoin.Areas.CRM2.Models
{
    public class DonationsViewModel
    {
        public int ID { get; set; }
        public int HouseholdID { get; set; }
        public int TransTypeID { get; set; }
        public int TransIncrID { get; set; }
        public int TransMethID { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Amount { get; set; }

    }
}