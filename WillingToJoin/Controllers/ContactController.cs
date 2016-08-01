using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WillingToJoin.Models;

namespace WillingToJoin.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }



		[HttpPost]
		public ActionResult Index(ContactViewModel contactViewModel)
		{
			if (ModelState.IsValid)
			{
				string emailFrom = ConfigurationManager.AppSettings["emailFrom"];
				string passwordFrom = ConfigurationManager.AppSettings["passwordFrom"];
				string smtpClientHost = ConfigurationManager.AppSettings["smtpClientHost"];
				string emailTo = ConfigurationManager.AppSettings["emailTo"];
				int smtpClientPort = int.Parse(ConfigurationManager.AppSettings["smtpClientPort"]);
				string type = (contactViewModel.Type == 1) ? "General" : "Prayer Team";

				MailMessage mail = new MailMessage(emailFrom, emailTo);
				mail.Subject = "Willing to Join";
				mail.Body = string.Format("Name: {0}\n\rType: {1}\n\rEmail: {2}\n\rMessage: {3}", contactViewModel.Name, type, contactViewModel.Email, contactViewModel.Message);

				SmtpClient client = new SmtpClient();
				client.Host = smtpClientHost;
				client.Port = smtpClientPort;
				client.DeliveryMethod = SmtpDeliveryMethod.Network;
				client.Credentials = new NetworkCredential(emailFrom, passwordFrom);
				client.Send(mail);
			}
			else
			{
				contactViewModel = new ContactViewModel();
			}
			return View(contactViewModel);
		}
	}
}