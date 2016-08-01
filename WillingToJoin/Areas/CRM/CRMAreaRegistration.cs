using System.Reflection;
using System.Web.Mvc;

namespace WillingToJoin.Areas.CRM
{
    public class CRMAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CRM";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CRM_default",
                "CRM/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "WillingToJoin.Areas.CRM.Controllers" }
            );
        }
    }
}