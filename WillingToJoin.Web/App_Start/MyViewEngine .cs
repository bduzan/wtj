using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.IO;
using Umbraco.Core.Logging;
using Umbraco.Core.IO;
using Umbraco.Core;

namespace WillingToJoin.Web.App_Start
{
    public class MyViewEngine : RazorViewEngine
    {
        public MyViewEngine()
        {
            var viewsPath = IOHelper.MapPath("~/Views");
            

            var directories = Directory.GetDirectories(viewsPath);
          

            var pathList = new List<string>();

            foreach (var directory in directories.Where(x => !x.ToLower().Contains("partials") && !x.ToLower().Contains("macropartials")))
            {
                var folder = Path.GetFileName(directory);

                var path = string.Format("~/Views/{0}/{{0}}.cshtml", folder);
               

                pathList.Add(path);
               
                LogHelper.Info<MyViewEngine>("Registering view engine path: " + folder);
            }
            

            ViewLocationFormats = ViewLocationFormats.Union(pathList).ToArray();
        }
    }

    
}