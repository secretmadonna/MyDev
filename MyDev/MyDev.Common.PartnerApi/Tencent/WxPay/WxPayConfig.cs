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
        public const string APPID = "wxa1e090819f42345a";
        /// <summary>
        /// MCHID：商户号（必须配置）
        /// </summary>
        public const string MCHID = "1293045101";
        /// <summary>
        /// KEY：商户支付密钥，参考开户邮件设置（必须配置）
        /// </summary>
        public const string KEY = "Fv7W10U5144voaGbBEj1yC8s844a10t0";
        /// <summary>
        /// APPSECRET：公众帐号secert（仅JSAPI支付的时候需要配置）
        /// </summary>
        public const string APPSECRET = "94c0b2e95b44f9c5302bcb6c0534671b ";

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
