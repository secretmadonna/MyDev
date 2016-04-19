using MyDev.Common.PartnerApi.Tencent.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MyDev.Common.PartnerApi.Tencent
{
    public class TenHelper
    {
        public static string AppId
        {
            get
            {

#if DEBUG
                return "wx9b23dda55a2be5a6";
#else
                return "wx28f127bb97dfed4a";
#endif
            }
        }

        public static string AppSecret
        {
            get
            {
#if DEBUG
                return "38d8fa2ebd7bc528c210cbc0e4741880";
#else
                return "ac2ab8f81e99c93c647cb279f65f983b"; 
#endif
            }
        }

        private static AccessTokenModel GetAccessToken(string appid = "APPID", string appsecret = "APPSECRET", string grant_type = "client_credential")
        {
            try
            {
                //每日限额：2000
                var strUrl = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type={0}&appid={1}&secret={2}", grant_type, appid, appsecret);
                var content = WebRequestHelper.DoGetRequest(strUrl, Encoding.UTF8);
                var model = TypeHelper.JsonToObject<AccessTokenModel>(content);
                return model;
            }
            catch (Exception ex)
            {
                //日志记录？？？
                throw ex;
            }
        }
        /// <summary>
        /// 从文件中获取 AccessToken
        /// 如果从文件中获取的 AccessToken 已过期，重新向微信服务器请求 AccessToken，并将新的 AccessToken 更新到文件中
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetAccessToken(string fileName = "/Ten/token.xml")
        {
            string tokenFilePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            if (File.Exists(tokenFilePath))
            {
                var xmlDoc = new XmlDocument();
                using (var sr = new StreamReader(tokenFilePath, Encoding.UTF8))
                {
                    xmlDoc.Load(sr);
                }
                var root = xmlDoc.DocumentElement;
                if (root == null || root.Name != "root")
                {
                    return null;
                }
                var token = root.SelectSingleNode("accesstoken");
                var expirationTime = root.SelectSingleNode("accessexpirationtime");
                if (token == null || expirationTime == null)
                {
                    return null;
                }
                var dtExpirationTime = DateTime.MinValue;
                DateTime.TryParse(expirationTime.InnerText, out dtExpirationTime);
                var now = DateTime.Now;
                if (string.IsNullOrEmpty(token.InnerText) || string.IsNullOrEmpty(expirationTime.InnerText) || (dtExpirationTime != DateTime.MinValue && dtExpirationTime < now))
                {
                    var model = GetAccessToken(AppId, AppSecret);
                    token.InnerText = model.AccessToken;
                    expirationTime.InnerText = now.AddSeconds(model.ExpiresIn).ToString("yyyy-MM-dd HH:mm:ss");
                    xmlDoc.Save(tokenFilePath);
                    return model.AccessToken;
                }
                return token.InnerText;
            }
            else
            {
                var xmlDoc = new XmlDocument();
                //创建类型声明节点  
                var node = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                xmlDoc.AppendChild(node);
                //创建根节点  
                var root = xmlDoc.CreateElement("root");
                xmlDoc.AppendChild(root);
                //创建2个子节点
                var token = xmlDoc.CreateElement("accesstoken");
                token.InnerText = null;
                root.AppendChild(token);
                var expirationTime = xmlDoc.CreateElement("accessexpirationtime");
                expirationTime.InnerText = null;
                root.AppendChild(expirationTime);
                //保存文件
                xmlDoc.Save(tokenFilePath);
                return GetAccessToken(fileName);
            }
        }

        public static bool GetMedia(string accessToken, string mediaId)
        {
            var strUrl = string.Format("https://api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}", accessToken, mediaId);
            return false;
        }
    }
}
