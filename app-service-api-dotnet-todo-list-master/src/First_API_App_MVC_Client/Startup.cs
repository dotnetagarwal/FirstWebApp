using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(First_API_App_MVC_Client.Startup))]
namespace First_API_App_MVC_Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
