using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDev.UserInterface.WebSite.Portal.Web.Controllers
{
    public class TestAjaxController : Controller
    {
        // GET: TestAjax
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetJson(dynamic parmsData)
        {
            var obj = new { StatusCode = 100, StatusDescription = "StatusDescription", ReturnData = new { Key1 = "Value1", Key2 = "Value2", ParamsData = parmsData } };
            return Json(obj);
        }

        [HttpPost]
        public JsonResult SaveFormData(dynamic parmsData)
        {
            var obj = new { StatusCode = 100, StatusDescription = "StatusDescription", ReturnData = new { Key1 = "Value1", Key2 = "Value2", ParamsData = parmsData } };
            return Json(obj);
        }
    }
}