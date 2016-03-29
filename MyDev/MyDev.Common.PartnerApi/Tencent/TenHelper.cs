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
        private static AccessTokenModel GetAccessToken(string grant_type = "client_credential", string appid = "APPID", string appsecret = "APPSECRET")
        {
            try
            {
                var strUrl = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type={0}&appid={1}&secret={2}", grant_type, appid, appsecret);
                var content = WebRequestHelper.DoGetRequest(strUrl, Encoding.UTF8);
                var model = TypeHelper.ToObject<AccessTokenModel>(content);
                return model;
            }
            catch (Exception ex)
            {
                //日志记录？？？
                throw ex;
            }
        }
        /// <summary>
        /// 从文件中获取AccessToken
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetAccessToken(string fileName = "token.xml")
        {
            string tokenFilePath = Path.Combine(Directory.GetCurrentDirectory() , fileName);
            if (File.Exists(tokenFilePath))
            {
                using (var sr = new StreamReader(tokenFilePath, Encoding.UTF8))
                {
                    var xml = new XmlDocument();
                    xml.Load(sr);
                    var token = xml.SelectSingleNode("xml");
                }
                var xmlDoc = new XmlDocument();
                //创建类型声明节点  
                XmlNode node = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "");
                xmlDoc.AppendChild(node);
                //创建根节点  
                XmlNode root = xmlDoc.CreateElement("xml");
                xmlDoc.AppendChild(root);
                xmlDoc.Save(tokenFilePath);
            }
            else
            {

            }
            return null;
        }
    }
}
