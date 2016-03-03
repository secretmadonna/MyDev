using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyDev.UserInterface.WebSite.Portal.Web.Startup))]
namespace MyDev.UserInterface.WebSite.Portal.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
