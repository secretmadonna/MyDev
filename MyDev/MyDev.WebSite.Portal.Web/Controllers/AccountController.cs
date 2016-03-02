using MyDev.WebSite.Portal.Web.Models;
using MyDev.WebSite.Portal.WebLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDev.WebSite.Portal.Web.Controllers
{
    public class AccountController : BaseController
    {
        [HttpGet]
        public ActionResult Login(string returnUrl = "/")
        {
            var model = new LoginVm() { ReturnUrl = returnUrl };
            return View(model);
        }
        [HttpPost]
        public JsonResult Login(LoginVm vm)
        {
            return Json(null);
        }
    }
}