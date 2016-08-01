using System.Threading.Tasks;
using WillingToJoin.Shared.Gateways;
using Microsoft.AspNet.Identity;

namespace WillingToJoin.Shared.Services.Messaging
{
    public class SmsService : IIdentityMessageService, ISmsService
    {
        private readonly ITwilioGateway _twilioGateway;

        public SmsService(ITwilioGateway twilioGateway)
        {
            _twilioGateway = twilioGateway;
        }

        public void SendSms(string phoneNumber, string message)
        {
            _twilioGateway.SendSms(phoneNumber, message);
        }

        public async Task SendAsync(IdentityMessage message)
        {
            await Task.Run(() => _twilioGateway.SendSms(message.Destination, message.Body));
        }
    }
}
