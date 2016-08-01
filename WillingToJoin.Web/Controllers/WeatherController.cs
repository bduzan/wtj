using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;



namespace WillingToJoin.Web.Controllers
{
    public class WeatherController : Umbraco.Web.Mvc.SurfaceController
    {
        // GET: /Weather/
        public ActionResult Index()
        {
            return View();
        }
        public class WeatherDetails
        {
            public string Temprature { get; set; }
            public string RealFeel { get; set; }
            public string OtherDetails { get; set; }
            public string FeatureSun { get; set; }

        }
        public JsonResult getWeatherDetails()
        {

            WeatherDetails objWeatherDetails = new WeatherDetails();
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load("http://www.accuweather.com/en/tz/arusha/317029/current-weather/317029");
            // objWeatherDetails.Temprature = document.DocumentNode.SelectNodes("//span[@class='cond']").FirstOrDefault().InnerHtml;
            objWeatherDetails.Temprature = document.DocumentNode.SelectNodes("//span[@class='temp']").FirstOrDefault().InnerHtml;
            objWeatherDetails.RealFeel = document.DocumentNode.SelectNodes("//span[@class='small-temp']").FirstOrDefault().InnerHtml;
            objWeatherDetails.OtherDetails = document.DocumentNode.SelectNodes("//ul[@class='stats']").FirstOrDefault().InnerHtml;
            objWeatherDetails.FeatureSun = document.DocumentNode.SelectNodes("//ul[@class='time-period']").FirstOrDefault().InnerHtml;
            return Json(objWeatherDetails, JsonRequestBehavior.AllowGet);
        }
    }
}