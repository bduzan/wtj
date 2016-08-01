using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using Umbraco.Web;
using WillingToJoin.Web.App_Start;

namespace WillingToJoin.Web
{

    public class MvcApplication : UmbracoApplication
    {
        protected override void OnApplicationStarted(object sender, EventArgs e)
        {
            base.OnApplicationStarted(sender, e);
           // BundleConfig.RegisterBundles(BundleTable.Bundles);
            NinjectModule registrations = new NinjectWebCommon();
            var kernel = new StandardKernel(registrations);
            var ninjectResolver = new NinjectDependencyResolver(kernel);
            DependencyResolver.SetResolver(ninjectResolver);
        }
        protected override void OnApplicationError(object sender, EventArgs e)
        {

            bool isAjaxCall = string.Equals("XMLHttpRequest", Context.Request.Headers["x-requested-with"], StringComparison.OrdinalIgnoreCase);

            Exception exception = System.Web.HttpContext.Current.Server.GetLastError();    
            var currentRequest = HttpContext.Current;
            StreamWriter sw = new StreamWriter(Path.Combine(currentRequest.Server.MapPath("~/Logs"), "errorLog.txt"), true);
            sw.WriteLine("\n\n" + DateTime.Now.ToString() + "\n(1) Error Message : " + exception.Message + "\n(2) Inner Exception :" + exception.InnerException);
            sw.Flush();
            sw.Close();

            string exceptionMsg = exception.Message;
            Context.ClearError();
            //if (isAjaxCall)
            //{
               
            //    Response.Clear();
            //    Response.TrySkipIisCustomErrors = true;
            //    Response.ContentType = "application/json";
            //    //Response.StatusCode = 500;
            //    Response.Write(exceptionMsg);
            //    Response.End();
            //}
            //else
            //{
            //    Server.ClearError();
            //    Session["error"] = exceptionMsg;
            //    //Response.Redirect("/Error/Error");
            //}
        }
    }

   


}
