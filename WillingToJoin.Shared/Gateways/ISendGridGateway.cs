using System.Threading.Tasks;
using SendGrid;

namespace WillingToJoin.Shared.Gateways
{
    public interface ISendGridGateway
    {
        void Send(SendGridMessage message);
        Task SendAsync(SendGridMessage message);
    }
}