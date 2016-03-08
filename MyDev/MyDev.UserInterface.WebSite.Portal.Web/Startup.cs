using Microsoft.Owin;
using MyDev.Common;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(MyDev.UserInterface.WebSite.Portal.Web.Startup))]
namespace MyDev.UserInterface.WebSite.Portal.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            LogHelper.Write(System.IO.Path.Combine(System.Environment.CurrentDirectory, "LogFile", "OwinMvc.txt"), null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " Startup.Configuration.\r\n");
            ConfigureAuth(app);
        }
    }
}
