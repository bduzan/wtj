using SendGrid;

namespace WillingToJoin.Shared.Services.Messaging
{
    public interface IEmailService
    {
        void Send(SendGridMessage message);
        void Send(string to, string subject, string message);
        void Send(string subject, string message);
    }
}