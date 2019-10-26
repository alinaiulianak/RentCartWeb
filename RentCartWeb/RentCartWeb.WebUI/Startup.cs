using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RentCartWeb.WebUI.Startup))]
namespace RentCartWeb.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
