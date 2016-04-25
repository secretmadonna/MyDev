using MyDev.Common.PartnerApi.Tencent.Wx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.Common.PartnerApi.Tencent.WxPay
{
    public class WxPayApiHelper
    {
        public static WxPayData UnifiedOrder(WxPayData reqParams)
        {
            string strUrl = "https://api.mch.weixin.qq.com/pay/unifiedorder";
            //检测请求必填参数
            if (!reqParams.HasSetValue("body"))
            {
                throw new WxPayException("统一下单中，缺少必填参数 body！");
            }
            else if (!reqParams.HasSetValue("out_trade_no"))
            {
                throw new WxPayException("统一下单中，缺少必填参数 out_trade_no！");
            }
            else if (!reqParams.HasSetValue("total_fee"))
            {
                throw new WxPayException("统一下单中，缺少必填参数 total_fee！");
            }
            else if (!reqParams.HasSetValue("spbill_create_ip"))
            {
                //APP和网页支付提交用户端IP，Native支付填调用微信支付API的机器IP。
                throw new WxPayException("统一下单中，缺少必填参数 spbill_create_ip！");
            }
            //else if (!reqParams.HasSetValue("notify_url"))
            //{
            //    //接收微信支付异步通知回调地址，通知url必须为直接可访问的url，不能携带参数。
            //    throw new WxPayException("统一下单中，缺少必填参数 spbill_create_ip！");
            //}
            else if (!reqParams.HasSetValue("trade_type"))
            {
                throw new WxPayException("统一下单中，缺少必填参数 trade_type！");
            }

            //关联请求参数
            if (reqParams.GetValue("trade_type").ToString() == "JSAPI" && !reqParams.HasSetValue("openid"))
            {
                throw new WxPayException("统一下单中，缺少必填参数 openid！trade_type 为 JSAPI 时，openid 为必填参数！");
            }
            else if (reqParams.GetValue("trade_type").ToString() == "NATIVE" && !reqParams.HasSetValue("product_id"))
            {
                throw new WxPayException("统一下单中，缺少必填参数 product_id！trade_type 为 NATIVE 时，product_id 为必填参数！");
            }

            //其他请求参数
            if (!reqParams.HasSetValue("notify_url"))
            {
                //接收微信支付异步通知回调地址，通知url必须为直接可访问的url，不能携带参数。
                reqParams.SetValue("notify_url", WxPayConfig.NOTIFY_URL);
            }
            reqParams.SetValue("appid", WxPayConfig.APPID);
            reqParams.SetValue("mch_id", WxPayConfig.MCHID);
            //reqParams.SetValue("spbill_create_ip", WxPayConfig.IP);
            reqParams.SetValue("nonce_str", WxHelper.GenerateNonceStr());
            reqParams.SetValue("sign", reqParams.MakeSign());

            //请求参数转XML
            string xml = reqParams.ToXml();

            //发送请求，得到相应
            string response = HttpHelper.WxPayPost(strUrl, xml);

            var result = new WxPayData();
            result.FromXml(response);

            return result;
        }

        public static WxPayData OrderQuery(WxPayData reqParams)
        {
            string strUrl = "https://api.mch.weixin.qq.com/pay/orderquery";
            //检测请求必填参数
            if (!reqParams.HasSetValue("transaction_id") && !reqParams.HasSetValue("out_trade_no"))
            {
                throw new WxPayException("查询订单中，transaction_id、out_trade_no至少填一个！");
            }

            //其他请求参数
            reqParams.SetValue("appid", WxPayConfig.APPID);
            reqParams.SetValue("mch_id", WxPayConfig.MCHID);
            reqParams.SetValue("nonce_str", WxHelper.GenerateNonceStr());
            reqParams.SetValue("sign", reqParams.MakeSign());

            //请求参数转XML
            string xml = reqParams.ToXml();

            //发送请求，得到相应
            string response = HttpHelper.WxPayPost(strUrl, xml);

            var result = new WxPayData();
            result.FromXml(response);

            return result;
        }

        public static WxPayData CloseOrder(WxPayData reqParams)
        {
            string strUrl = "https://api.mch.weixin.qq.com/pay/closeorder";
            //检测请求必填参数
            if (!reqParams.HasSetValue("out_trade_no"))
            {
                throw new WxPayException("关闭订单中，缺少必填参数 out_trade_no！");
            }

            //其他请求参数
            reqParams.SetValue("appid", WxPayConfig.APPID);
            reqParams.SetValue("mch_id", WxPayConfig.MCHID);
            reqParams.SetValue("nonce_str", WxHelper.GenerateNonceStr());
            reqParams.SetValue("sign", reqParams.MakeSign());

            //请求参数转XML
            string xml = reqParams.ToXml();

            //发送请求，得到相应
            string response = HttpHelper.WxPayPost(strUrl, xml);

            var result = new WxPayData();
            result.FromXml(response);

            return result;
        }

        public static WxPayData Refund(WxPayData reqParams)
        {
            var strUrl = "https://api.mch.weixin.qq.com/secapi/pay/refund";
            //检测请求必填参数
            if (!reqParams.HasSetValue("transaction_id") && !reqParams.HasSetValue("out_trade_no"))
            {
                throw new WxPayException("退款申请接口中，transaction_id、out_trade_no 至少填一个！");
            }
            else if (!reqParams.HasSetValue("out_refund_no"))
            {
                throw new WxPayException("退款申请接口中，缺少必填参数 out_refund_no！");
            }
            else if (!reqParams.HasSetValue("total_fee"))
            {
                throw new WxPayException("退款申请接口中，缺少必填参数 total_fee！");
            }
            else if (!reqParams.HasSetValue("refund_fee"))
            {
                throw new WxPayException("退款申请接口中，缺少必填参数 refund_fee！");
            }
            else if (!reqParams.HasSetValue("op_user_id"))
            {
                throw new WxPayException("退款申请接口中，缺少必填参数 op_user_id！");
            }
            //其他请求参数
            reqParams.SetValue("appid", WxPayConfig.APPID);
            reqParams.SetValue("mch_id", WxPayConfig.MCHID);
            reqParams.SetValue("nonce_str", WxHelper.GenerateNonceStr());
            reqParams.SetValue("sign", reqParams.MakeSign());

            //请求参数转XML
            var xml = reqParams.ToXml();

            //发送请求，得到相应
            var response = HttpHelper.WxPayPost(strUrl, xml);//WxPayHttpHelper.Post(strUrl, xml, true);

            var result = new WxPayData();
            result.FromXml(response);

            return result;
        }

        public static WxPayData RefundQuery(WxPayData reqParams)
        {
            string strUrl = "https://api.mch.weixin.qq.com/pay/refundquery";
            //检测必填参数
            if (!reqParams.HasSetValue("refund_id") && !reqParams.HasSetValue("out_refund_no")
                && !reqParams.HasSetValue("transaction_id") && !reqParams.HasSetValue("out_trade_no"))
            {
                throw new WxPayException("退款查询接口中，refund_id、out_refund_no、transaction_id、out_trade_no 至少填一个！");
            }
            //其他请求参数
            reqParams.SetValue("appid", WxPayConfig.APPID);
            reqParams.SetValue("mch_id", WxPayConfig.MCHID);
            reqParams.SetValue("nonce_str", WxHelper.GenerateNonceStr());
            reqParams.SetValue("sign", reqParams.MakeSign());

            //请求参数转XML
            string xml = reqParams.ToXml();

            //发送请求，得到相应
            string response = HttpHelper.WxPayPost(strUrl, xml);//WxPayHttpHelper.Post(strUrl, xml, false);

            var result = new WxPayData();
            result.FromXml(response);

            return result;
        }

        public static WxPayData DownloadBill(WxPayData reqParams)
        {
            string strUrl = "https://api.mch.weixin.qq.com/pay/downloadbill";
            //检测请求必填参数
            if (!reqParams.HasSetValue("bill_date"))
            {
                throw new WxPayException("下载对账单中，缺少必填参数 bill_date！");
            }

            //其他请求参数
            reqParams.SetValue("appid", WxPayConfig.APPID);
            reqParams.SetValue("mch_id", WxPayConfig.MCHID);
            reqParams.SetValue("nonce_str", WxHelper.GenerateNonceStr());
            reqParams.SetValue("sign", reqParams.MakeSign());

            //请求参数转XML
            string xml = reqParams.ToXml();

            //发送请求，得到相应
            string response = HttpHelper.WxPayPost(strUrl, xml);

            var result = new WxPayData();
            result.FromXml(response);

            return result;
        }

        public static WxPayData Report(WxPayData reqParams)
        {
            string strUrl = "https://api.mch.weixin.qq.com/payitil/report";
            //检测请求必填参数
            if (!reqParams.HasSetValue("interface_url"))
            {
                throw new WxPayException("测速上报中，缺少必填参数 interface_url！");
            }
            else if (!reqParams.HasSetValue("execute_time_"))
            {
                throw new WxPayException("测速上报中，缺少必填参数 execute_time_！");
            }
            else if (!reqParams.HasSetValue("return_code"))
            {
                throw new WxPayException("测速上报中，缺少必填参数 return_code！");
            }
            else if (!reqParams.HasSetValue("result_code"))
            {
                throw new WxPayException("测速上报中，缺少必填参数 result_code！");
            }
            else if (!reqParams.HasSetValue("user_ip"))
            {
                throw new WxPayException("测速上报中，缺少必填参数 user_ip！");
            }


            //其他请求参数
            reqParams.SetValue("appid", WxPayConfig.APPID);
            reqParams.SetValue("mch_id", WxPayConfig.MCHID);
            reqParams.SetValue("nonce_str", WxHelper.GenerateNonceStr());
            reqParams.SetValue("sign", reqParams.MakeSign());

            //请求参数转XML
            string xml = reqParams.ToXml();

            //发送请求，得到相应
            string response = HttpHelper.WxPayPost(strUrl, xml);

            var result = new WxPayData();
            result.FromXml(response);

            return result;
        }
    }
}
