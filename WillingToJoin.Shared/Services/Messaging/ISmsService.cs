using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace WillingToJoin.Shared.Services.Messaging
{
    public interface ISmsService
    {
        void SendSms(string phoneNumber, string message);
        Task SendAsync(IdentityMessage message);
    }
}