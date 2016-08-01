using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WillingToJoin.Shared.Utils;
using SendGrid;

namespace WillingToJoin.Shared.Gateways
{
    public class SendGridGateway : ISendGridGateway
    {
        private readonly string _sendGridUsername = ConfigurationManager.AppSettings["SendGridUsername"];
        private readonly string _sendGridPassword = ConfigurationManager.AppSettings["SendGridPassword"];
        private readonly string _sendGridEmailFrom = ConfigurationManager.AppSettings["SendGridEmailFrom"];
        private readonly string _sendGridDisplayName = ConfigurationManager.AppSettings["SendGridDisplayName"];

        public void Send(SendGridMessage message)
        {
            try
            {
                // Create network credentials to access your SendGrid account.
                var credentials = new NetworkCredential(_sendGridUsername, _sendGridPassword);

                // Create an Web transport for sending email.
                var transportWeb = new Web(credentials);

                // Disable Unsubsribe
                message.DisableUnsubscribe();

                if (ConfigUtil.IsDevelopment())
                {
                    var email = ConfigurationManager.AppSettings["DebugEmail"];

                    var testMessage = new SendGridMessage
                    {
                        Subject = message.Subject,
                        Html = message.Html,
                        Attachments = message.Attachments,
                        StreamedAttachments = message.StreamedAttachments
                    };

                    testMessage.AddTo(email);
                    testMessage.From = new MailAddress(email, _sendGridDisplayName);

                    Task.Run(async () => await transportWeb.DeliverAsync(testMessage));
                }
                else
                {
                    message.From = new MailAddress(_sendGridEmailFrom, _sendGridDisplayName);
                    Task.Run(async () => await transportWeb.DeliverAsync(message));
                }
            }
            catch (Exception exception)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(exception);
            }
        }

        public async Task SendAsync(SendGridMessage message)
        {
            try
            {
                // Create network credentials to access your SendGrid account.
                var credentials = new NetworkCredential(_sendGridUsername, _sendGridPassword);

                // Create an Web transport for sending email.
                var transportWeb = new Web(credentials);

                // Disable Unsubsribe
                message.DisableUnsubscribe();

                if (ConfigUtil.IsDevelopment())
                {
                    var email = ConfigurationManager.AppSettings["DebugEmail"];
                    var displayName = ConfigurationManager.AppSettings["SendGridDisplayName"];

                    var testMessage = new SendGridMessage
                    {
                        Subject = message.Subject,
                        Html = message.Html,
                        Attachments = message.Attachments,
                        StreamedAttachments = message.StreamedAttachments
                    };

                    testMessage.AddTo(email);
                    testMessage.From = new MailAddress(email, displayName);

                    await transportWeb.DeliverAsync(testMessage);
                }
                else
                {
                    await transportWeb.DeliverAsync(message);
                }
            }
            catch (Exception exception)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(exception);
            }
        }
    }
}
