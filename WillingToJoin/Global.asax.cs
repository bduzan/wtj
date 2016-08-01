using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WillingToJoin.App_Start;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System;
using System.Configuration;
using System.IO;

namespace WillingToJoin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // For using Test DataBase. In prodaction better remove
            var oldDataDirectory = AppDomain.CurrentDomain.GetData("DataDirectory");
            var newDataDirectory = ConfigurationManager.AppSettings["DataDirectory"];
            var absoluteDataDirectory = Path.GetFullPath(Path.Combine(oldDataDirectory.ToString(), newDataDirectory));
            AppDomain.CurrentDomain.SetData("DataDirectory", absoluteDataDirectory);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);
            var ninjectResolver = new NinjectDependencyResolver(kernel);

            DependencyResolver.SetResolver(ninjectResolver);
        }
    }
}
