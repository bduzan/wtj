using System.Web.Mvc;

namespace WillingToJoin.Areas.CRM2
{
    public class CRM2AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CRM2";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CRM2_default",
                "CRM2/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}