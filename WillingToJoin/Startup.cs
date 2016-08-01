using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WillingToJoin.Startup))]
namespace WillingToJoin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
