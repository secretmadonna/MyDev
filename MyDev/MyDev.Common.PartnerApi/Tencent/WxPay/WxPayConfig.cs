using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.Common.PartnerApi.Tencent.WxPay
{
    public class WxPayConfig
    {
        #region 基本信息设置

        /// <summary>
        /// APPID：绑定支付的APPID（必须配置）
        /// </summary>
        public const string APPID = "wx2428e34e0e7dc6ef";
        /// <summary>
        /// MCHID：商户号（必须配置）
        /// </summary>
        public const string MCHID = "1233410002";
        /// <summary>
        /// KEY：商户支付密钥，参考开户邮件设置（必须配置）
        /// </summary>
        public const string KEY = "e10adc3849ba56abbe56e056f20f883e";
        /// <summary>
        /// APPSECRET：公众帐号secert（仅JSAPI支付的时候需要配置）
        /// </summary>
        public const string APPSECRET = "51c56b886b5be869567dd389b3e5d1d6";

        #endregion

        #region 证书设置(仅退款、撤销订单时需要)

        public const string SSLCERT_PATH = "/Ten/cert/apiclient_cert.p12";
        public const string SSLCERT_PASSWORD = "1233410002";

        #endregion

        #region 代理服务器设置

        public const string PROXY_URL = "";

        #endregion
    }
}
