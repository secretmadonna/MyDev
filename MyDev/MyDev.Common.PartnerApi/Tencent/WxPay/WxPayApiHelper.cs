using MyDev.Common.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.Common.PartnerApi.Tencent.WxPay
{
    public class WxPayApiHelper
    {
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
            reqParams.SetValue("nonce_str", GenerateNonceStr());
            reqParams.SetValue("sign", reqParams.MakeSign());

            //请求参数转XML
            var xml = reqParams.ToXml();
            
            //发送请求，得到相应
            var response = WxPayHttpHelper.Post(strUrl, xml, true);

            var result = new WxPayData();
            result.FromXml(response);

            return result;
        }

        public static WxPayData RefundQuery(WxPayData reqParams)
        {
            string strUrl = "https://api.mch.weixin.qq.com/pay/refundquery";
            //检测必填参数
            if (!reqParams.HasSetValue("refund_id") && !reqParams.HasSetValue("out_refund_no")
                &&!reqParams.HasSetValue("transaction_id") && !reqParams.HasSetValue("out_trade_no"))
            {
                throw new WxPayException("退款查询接口中，refund_id、out_refund_no、transaction_id、out_trade_no 至少填一个！");
            }
            //其他请求参数
            reqParams.SetValue("appid", WxPayConfig.APPID);
            reqParams.SetValue("mch_id", WxPayConfig.MCHID);
            reqParams.SetValue("nonce_str", GenerateNonceStr());
            reqParams.SetValue("sign", reqParams.MakeSign());

            //请求参数转XML
            string xml = reqParams.ToXml();

            //发送请求，得到相应
            string response = WxPayHttpHelper.Post( strUrl,xml, false);
            
            var result = new WxPayData();
            result.FromXml(response);

            return result;
        }

        private static string GenerateNonceStr()
        {
            return Guid.NewGuid().ToString().Replace("-", string.Empty);
        }
    }
}
