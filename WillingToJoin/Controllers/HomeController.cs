using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using WillingToJoin.Models;

namespace WillingToJoin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


	}
}