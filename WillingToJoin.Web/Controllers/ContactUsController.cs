using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using umbraco.cms.businesslogic.web;
using WillingToJoin.Web.Models;
namespace WillingToJoin.Web.Controllers
{
    public class ContactUsController : Umbraco.Web.Mvc.SurfaceController
    {
        [HttpPost]
        public ActionResult SendMail(ContactUs form)
        {
            string retValue = "There was an error submitting the form, please try again later.";
            if (!ModelState.IsValid)
            {
                TempData["message"] = "ValidatoinFailed";
                return RedirectToCurrentUmbracoUrl();
            }
            if (ModelState.IsValid)
            {
                Document contactDoc = new Document(1603);
                var Host = contactDoc.getProperty("eHost").Value.ToString();
                int Port = Convert.ToInt32(contactDoc.getProperty("ePort").Value);
                var EmailUsername = contactDoc.getProperty("eUsername").Value.ToString();
                var EmailPassword = contactDoc.getProperty("ePassword").Value.ToString();
                var FromEmail = contactDoc.getProperty("eFromEmail").Value.ToString();
                bool EnableSSL = Convert.ToBoolean(contactDoc.getProperty("eEnableSsl").Value);
                var Message = Request.Form["message"];
                var Subject = Request.Form["subject"];
                using (var client = new SmtpClient
                {
                    Host = Host,
                    Port = Port,
                    EnableSsl = EnableSSL,
                    Credentials = new NetworkCredential(EmailUsername, EmailPassword),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                })
                {
                    var mail = new MailMessage();
                    string ToEmail = contactDoc.getProperty("emailRecipient").Value.ToString();
                    mail.To.Add(ToEmail);
                    mail.From = new MailAddress(FromEmail);
                    mail.Subject = "Message From " + form.Name;
                    mail.Body = "Name : " + form.Name + "\n" + "Email : " + form.Email;
                    mail.Body += "\n" + "Subject : " + Subject;
                    mail.Body += "\n" + "Message : " + Message;
                    mail.IsBodyHtml = false;
                    try
                    {
                        client.Send(mail);
                        TempData["message"] = "Information successfully submitted";
                        return CurrentUmbracoPage();
                    }
                    catch (Exception e)
                    {
                        var a = e.Message;
                    }
                }
            }
            return Content(retValue);
        }
    }
}