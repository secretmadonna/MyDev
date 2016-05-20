using System.Web.Mvc;

namespace MyDev.UserInterface.WebSite.Portal.Web.Areas.UserCenter
{
    public class UserCenterAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "UserCenter";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "UserCenter_default",
                "uc/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "MyDev.UserInterface.WebSite.Portal.Web.Areas.UserCenter.Controllers" }
            );
        }
    }
}