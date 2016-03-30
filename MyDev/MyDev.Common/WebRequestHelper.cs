using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.Common
{
    public class WebRequestHelper
    {
        public static string DoGetRequest(string url, Encoding encode)
        {
            try
            {
                //记录请求信息
                LogHelper.Write("request.txt", "info", "GetRequest : url = " + url + "\r\n");
                var request = (HttpWebRequest)WebRequest.Create(url) as HttpWebRequest;
                request.Method = "GET";
                using (var response = request.GetResponse())
                {
                    using (var sr = new StreamReader(response.GetResponseStream(), encode))
                    {
                        var content = sr.ReadToEnd();
                        //日志记录
                        LogHelper.Write("request.txt", "info", "GetRequest's Response : " + content + "\r\n");
                        return content;
                    }
                }
            }
            catch (Exception ex)
            {
                //日志记录？？？
                throw ex;
            }
        }
        public static string DoPostRequest(string url, SortedDictionary<string, string> param, Encoding encode)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url) as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                if (param.Any())
                {
                    var sb = new StringBuilder();
                    foreach (var item in param)
                    {
                        sb.Append(string.Format("{0}={1}&", item.Key, item.Value));
                    }
                    byte[] byteArray = encode.GetBytes(sb.ToString().Substring(0, sb.ToString().Length - 1));
                    request.ContentLength = byteArray.Length;
                    using (var s = request.GetRequestStream())
                    {
                        s.Write(byteArray, 0, byteArray.Length);
                    }
                }
                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    using (var sr = new StreamReader(response.GetResponseStream(), encode))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                //日志记录？？？
                throw ex;
            }
        }
    }
}
