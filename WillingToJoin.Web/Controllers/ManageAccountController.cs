using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using umbraco.cms.businesslogic.member;
using WillingToJoin.Web.Models;
using System.Web.Helpers;

using Umbraco.Web.Mvc;
using umbraco.BusinessLogic;
using System.Net.Mail;
using umbraco.cms.businesslogic.web;


namespace WillingToJoin.Web.Controllers
{
    public class ManageAccountController : Umbraco.Web.Mvc.SurfaceController
    {
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();
            var memberService = Services.MemberService;
            if (memberService.GetByEmail(model.Email) != null)
            {
                ModelState.AddModelError("", "Member already exists");
                TempData["RegisterMessage"] = "true";
                return CurrentUmbracoPage();
            }
            var member = memberService.CreateMemberWithIdentity(model.Email, model.Email, model.Email, "Member");
            member.SetValue("firstName", model.FirstName);
            member.SetValue("lastName", model.FirstName);
            memberService.Save(member);
            memberService.SavePassword(member, model.Password);
            Members.Login(model.Email, model.Password);
            return Redirect("/crm/account");
        }
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Email, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return Redirect("/crm/account");
                }
                else
                {
                    TempData["LoginMessage"] = "Invalid username or password";
                    return CurrentUmbracoPage();
                }
            }
            else
            {
                return CurrentUmbracoPage();
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult LogOff()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return CurrentUmbracoPage();
                }
                var memberEmail = Member.GetMemberFromEmail(model.Email);
                if (memberEmail != null)
                {
                    Document contactDoc = new Document(1603);
                    var Host = contactDoc.getProperty("eHost").Value.ToString();
                    int Port = Convert.ToInt32(contactDoc.getProperty("ePort").Value);
                    var EmailUsername = contactDoc.getProperty("eUsername").Value.ToString();
                    var EmailPassword = contactDoc.getProperty("ePassword").Value.ToString();
                    var FromEmail = contactDoc.getProperty("eFromEmail").Value.ToString();
                    bool EnableSSL = Convert.ToBoolean(contactDoc.getProperty("eEnableSsl").Value);

                    SmtpClient smtpClient = new SmtpClient(Host, Port);
                    smtpClient.Credentials = new System.Net.NetworkCredential(EmailUsername, EmailPassword);
                    //smtpClient.UseDefaultCredentials = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.EnableSsl = EnableSSL;
                    MailMessage mail = new MailMessage();

                    //Setting From , To and CC
                    mail.From = new MailAddress(EmailUsername, "WTJ");
                    mail.To.Add(new MailAddress(model.Email));
                    mail.Subject = "Forgot Password (WTJ)";

                    mail.Body = "Your Password is : " + memberEmail.Password;
                    mail.IsBodyHtml = false;

                    smtpClient.Send(mail);
                    TempData["ForgotPasswordStatus"] = "Password Sent. Please Check Your Email";
                }
                else
                {
                    TempData["ForgotPasswordStatus"] = "This Email is Not Exist";
                }
            }
            catch (Exception e)
            {
                return Content(Convert.ToString(e.InnerException));
            }
            return CurrentUmbracoPage();
        }

        public ActionResult ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return CurrentUmbracoPage();
            }
            try
            {
                var member = Member.GetCurrentMember();
                if (member != null)
                {
                    var enteredPassowrd = model.CurrentPassword;
                    var currentPassword = member.GetPassword();
                    var newPassword = model.NewPassword;
                    if (enteredPassowrd == currentPassword)
                    {
                        member.ChangePassword(newPassword);
                        member.Save();
                        Session.Clear();
                        Session.Abandon();
                        FormsAuthentication.SignOut();
                        return Redirect("/crm/login");
                    }
                    else
                    {
                        TempData["ResetPasswordStatus"] = "Current Password is Wrong. Please Enter Valid Current Password";
                    }
                }
            }
            catch (Exception e)
            {
                var exp = e.InnerException;
            }
            return CurrentUmbracoPage();
        }
    }
}