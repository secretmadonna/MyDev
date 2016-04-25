using MyDev.Common.PartnerApi.Tencent.Wx;
using MyDev.Common.PartnerApi.Tencent.WxPay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDev.UserInterface.WebSite.Portal.Web.Controllers
{
    public class WxPayController : Controller
    {
        public ActionResult Index()
        {

            #region wx.config

            var appId = WxHelper.AppId;
            var nonceStr = WxHelper.GenerateNonceStr();
            var timeStamp = WxHelper.GetTimeStamp();
            var sign = WxHelper.GetJssdkSign(nonceStr, timeStamp, Request.Url.AbsoluteUri);
            ViewBag.appId = appId;
            ViewBag.nonceStr = nonceStr;
            ViewBag.timeStamp = timeStamp;
            ViewBag.sign = sign;

            #endregion

            #region wx.chooseWXPay

            var wxPayData = new WxPayData();

            var body = string.Empty;
            wxPayData.SetValue("body", body);
            //var detail = string.Empty;
            //wxPayData.SetValue("detail", detail);
            //var attach = string.Empty;
            //wxPayData.SetValue("attach", attach);
            var out_trade_no = string.Empty;
            wxPayData.SetValue("out_trade_no", out_trade_no);
            var total_fee = string.Empty;
            wxPayData.SetValue("total_fee", total_fee);
            var spbill_create_ip = string.Empty;
            wxPayData.SetValue("spbill_create_ip", spbill_create_ip);
            var trade_type = string.Empty;
            wxPayData.SetValue("trade_type", trade_type);
            var openid = string.Empty;
            wxPayData.SetValue("openid", openid);
            var notify_url = string.Empty;
            wxPayData.SetValue("notify_url", notify_url);

            var respData = WxPayApiHelper.UnifiedOrder(wxPayData);

            #endregion

            return View();
        }

        //[HttpPost]
        public ContentResult WxPayAysnCallback()
        {
            var context = HttpContext;
            var data = new WxPayData();
            data.SetValue("return_code", "FAIL");
            data.SetValue("return_msg", "错误原因");
            var xml = data.ToXml();
            return Content(xml, "text/xml", System.Text.Encoding.UTF8);
        }
    }
}