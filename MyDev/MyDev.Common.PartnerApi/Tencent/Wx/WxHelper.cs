using MyDev.Common.PartnerApi.Tencent.Wx.Models;
using MyDev.Common.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MyDev.Common.PartnerApi.Tencent.Wx
{

    public class WxHelper
    {
        #region 所涉及的文件存放的根目录

        private static readonly string _absoluteDir = AppDomain.CurrentDomain.BaseDirectory;

        #endregion
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

        private static AccessTokenModel GetAccessToken(string appid, string appsecret, string grant_type = "client_credential")
        {
            try
            {
                //每日限额：2000
                var strUrl = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type={0}&appid={1}&secret={2}", grant_type, appid, appsecret);
                var content = HttpHelper.GetTextUseGet(strUrl);
                var model = TypeHelper.JsonToObject<AccessTokenModel>(content);
                if (!string.IsNullOrWhiteSpace(model.AccessToken) && model.ExpiresIn.HasValue && model.ExpiresIn.Value > 0)
                {
                    return model;
                }
                return null;
            }
            catch (Exception ex)
            {
                //记录日志？？？
                throw ex;
            }
        }
        /// <summary>
        /// 从文件中获取 AccessToken
        /// 如果从文件中获取的 AccessToken 已过期，重新向微信服务器请求 AccessToken，并将新的 AccessToken 更新到文件中
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetAccessToken(string fileName = "Wx/accesstoken.xml")
        {
            string tokenFilePath = Path.Combine(_absoluteDir, fileName);
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
                    if (model == null)
                    {
                        return null;
                    }
                    token.InnerText = model.AccessToken;
                    expirationTime.InnerText = now.AddSeconds(model.ExpiresIn.HasValue ? model.ExpiresIn.Value : 0).ToString("yyyy-MM-dd HH:mm:ss");
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
                if (!Directory.Exists(Path.GetDirectoryName(tokenFilePath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(tokenFilePath));
                }
                xmlDoc.Save(tokenFilePath);
                return GetAccessToken(fileName);
            }
        }

        private static JsapiTicketModel GetJsapiTicket(string accessToken, string type = "jsapi")
        {
            try
            {
                var strUrl = string.Format("https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type={1}", accessToken, type);
                var content = HttpHelper.GetTextUseGet(strUrl);
                var model = TypeHelper.JsonToObject<JsapiTicketModel>(content);
                if (!string.IsNullOrWhiteSpace(model.Ticket) && model.ExpiresIn.HasValue && model.ExpiresIn.Value > 0)
                {
                    return model;
                }
                return null;
            }
            catch (Exception ex)
            {
                //记录日志？？？
                throw ex;
            }
        }
        /// <summary>
        /// 从文件中获取 JsapiTicketModel
        /// 如果从文件中获取的 JsapiTicketModel 已过期，重新向微信服务器请求 JsapiTicketModel，并将新的 JsapiTicketModel 更新到文件中
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetJsapiTicket(string fileName = "Wx/jsapiticket.xml")
        {
            string ticketFilePath = Path.Combine(_absoluteDir, fileName);
            if (File.Exists(ticketFilePath))
            {
                var xmlDoc = new XmlDocument();
                using (var sr = new StreamReader(ticketFilePath, Encoding.UTF8))
                {
                    xmlDoc.Load(sr);
                }
                var root = xmlDoc.DocumentElement;
                if (root == null || root.Name != "root")
                {
                    return null;
                }
                var ticket = root.SelectSingleNode("ticket");
                var expirationTime = root.SelectSingleNode("accessexpirationtime");
                if (ticket == null || expirationTime == null)
                {
                    return null;
                }
                var dtExpirationTime = DateTime.MinValue;
                DateTime.TryParse(expirationTime.InnerText, out dtExpirationTime);
                var now = DateTime.Now;
                if (string.IsNullOrEmpty(ticket.InnerText) || string.IsNullOrEmpty(expirationTime.InnerText) || (dtExpirationTime != DateTime.MinValue && dtExpirationTime < now))
                {
                    var token = GetAccessToken();
                    if (string.IsNullOrWhiteSpace(token))
                    {
                        return null;
                    }
                    var ticketModel = GetJsapiTicket(token, "jsapi");
                    if (ticketModel == null)
                    {
                        return null;
                    }
                    ticket.InnerText = ticketModel.Ticket;
                    expirationTime.InnerText = now.AddSeconds(ticketModel.ExpiresIn.HasValue ? ticketModel.ExpiresIn.Value : 0).ToString("yyyy-MM-dd HH:mm:ss");
                    xmlDoc.Save(ticketFilePath);
                    return ticketModel.Ticket;
                }
                return ticket.InnerText;
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
                var ticket = xmlDoc.CreateElement("ticket");
                ticket.InnerText = null;
                root.AppendChild(ticket);
                var expirationTime = xmlDoc.CreateElement("accessexpirationtime");
                expirationTime.InnerText = null;
                root.AppendChild(expirationTime);
                //保存文件
                if (!Directory.Exists(Path.GetDirectoryName(ticketFilePath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(ticketFilePath));
                }
                xmlDoc.Save(ticketFilePath);
                return GetJsapiTicket(fileName);
            }
        }






        public static string GetJssdkSign(string nonceStr, long timeStamp, string url)
        {
            var ticket = GetJsapiTicket();
            if (!string.IsNullOrWhiteSpace(ticket))
            {
                var sortedDic = new SortedDictionary<string, object>();
                sortedDic.Add("jsapi_ticket", ticket);

                sortedDic.Add("noncestr", nonceStr);
                sortedDic.Add("timestamp", timeStamp);
                sortedDic.Add("url", url);

                var sb = new StringBuilder();
                foreach (var item in sortedDic)
                {
                    sb.AppendFormat("{0}={1}&", item.Key, item.Value);
                }
                var plainTextStr = sb.ToString().TrimEnd('&');
                var cipherText = HashAlgorithm.Encrypt(plainTextStr, HashWay.sha1, Encoding.UTF8);
                return cipherText;
            }
            return null;
        }


        public static bool GetMedia(string accessToken, string mediaId)
        {
            var strUrl = string.Format("https://api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}", accessToken, mediaId);
            return false;
        }






        private static char[] chars ={
            '0','1','2','3','4','5','6','7','8','9',
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
        };
        /// <summary>
        /// 生成随机字符串(1至30位，默认15位)
        /// </summary>
        /// <returns></returns>
        public static string GenerateNonceStr(int length = 15)
        {
            if (length < 1 || length > 30)
            {
                length = 15;
            }
            var random = new Random();
            var sb = new StringBuilder();
            var total = chars.Length;
            for (int i = 0; i < length; i++)
            {
                sb.Append(chars[random.Next(total - 1)]);
            }
            return sb.ToString();
            //return Guid.NewGuid().ToString().Replace("-", string.Empty);
        }
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static long GetTimeStamp()
        {
            return (DateTime.Now.ToUniversalTime().Ticks - DateTime.Parse("1970-01-01 00:00:00").Ticks) / 10000000;
        }
    }
}
