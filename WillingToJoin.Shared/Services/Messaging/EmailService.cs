using System.Configuration;
using System.Threading.Tasks;
using WillingToJoin.Shared.Gateways;
using Microsoft.AspNet.Identity;
using SendGrid;

namespace WillingToJoin.Shared.Services.Messaging
{
    public class EmailService : IIdentityMessageService, IEmailService
    {
        private readonly ISendGridGateway _sendGridGateway;

        private readonly string _systemEmail = ConfigurationManager.AppSettings["DebugNotifications"];

        public EmailService(ISendGridGateway sendGridGateway)
        {
            _sendGridGateway = sendGridGateway;
        }

        public void Send(SendGridMessage message)
        {
            _sendGridGateway.Send(message);
        }

        public void Send(string to, string subject, string message)
        {
            var mail = new SendGridMessage()
            {
                Subject = subject,
                Html = message,
            };

            mail.AddTo(to);
            _sendGridGateway.Send(mail);
        }

        public void Send(string subject, string message)
        {
            var mail = new SendGridMessage()
            {
                Html = message,
            };

            mail.AddTo(_systemEmail);
            _sendGridGateway.Send(mail);
        }

        public Task SendAsync(IdentityMessage message)
        {
            var mail = new SendGridMessage()
            {
                Subject = message.Subject,
                Html = message.Body,
            };

            mail.AddTo(message.Destination);
            return _sendGridGateway.SendAsync(mail);
        }
    }
}
