using System.Threading.Tasks;

namespace WillingToJoin.Shared.Gateways
{
    public interface ITwilioGateway
    {
        string SendSms(string phoneNumber, string message);
    }
}