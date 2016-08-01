using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;

namespace WillingToJoin.Web.App_Start
{
    public class RegisterViewEngine : ApplicationEventHandler
    {
       
        protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication,
            ApplicationContext applicationContext)
        {
            System.Web.Mvc.ViewEngines.Engines.Add(new MyViewEngine());

            base.ApplicationStarting(umbracoApplication, applicationContext);
        }
    }
}