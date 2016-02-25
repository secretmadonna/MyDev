using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDev.WebSite.Portal.Web.Areas.UserCenter.Controllers
{
    public class HomeController : Controller
    {
        // GET: UserCenter/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}