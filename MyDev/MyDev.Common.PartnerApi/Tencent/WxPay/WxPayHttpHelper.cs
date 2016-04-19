using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.Common.PartnerApi.Tencent.WxPay
{
    public class WxPayHttpHelper
    {
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
        public static string Post(string url, string xml, bool isUseCert = false, int timeout = 6)
        {
            System.GC.Collect();//垃圾回收，回收没有正常关闭的http连接

            var result = string.Empty;

            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                //设置最大连接数
                ServicePointManager.DefaultConnectionLimit = 200;
                //设置https验证方式
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                }

                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.Timeout = timeout * 1000;
                //设置代理服务器
                //request.Proxy = new WebProxy() { Address = new Uri(WxPayConfig.PROXY_URL) };
                //设置POST的数据类型和长度
                var reqCharset = Encoding.UTF8;
                var data = reqCharset.GetBytes(xml);
                request.ContentType = string.Format("{0}/{1}; charset={2}", "text", "xml", reqCharset.EncodingName);
                request.ContentLength = data.Length;
                //是否使用证书
                if (isUseCert)
                {
                    request.ClientCertificates.Add(new X509Certificate2(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, WxPayConfig.SSLCERT_PATH), WxPayConfig.SSLCERT_PASSWORD));
                }
                //往服务器写入数据
                using (var s = request.GetRequestStream())
                {
                    s.Write(data, 0, data.Length);
                }

                //获取服务端返回，处理返回
                response = (HttpWebResponse)request.GetResponse();
                if (!string.IsNullOrEmpty(response.ContentType) && response.ContentType.ToLower().Contains("text"))
                {
                    var respCharset = Encoding.UTF8;
                    if (!string.IsNullOrEmpty(response.CharacterSet))
                    {
                        respCharset = Encoding.GetEncoding(response.CharacterSet);
                    }
                    using (var sr = new StreamReader(response.GetResponseStream(), respCharset))
                    {
                        result = sr.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new WxPayException(ex.ToString());
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
                if (request != null)
                {
                    request.Abort();
                    request = null;
                }
            }
            return result;
        }

        public static string Get(string url)
        {
            System.GC.Collect();//垃圾回收，回收没有正常关闭的http连接

            var result = string.Empty;

            HttpWebRequest request = null;
            HttpWebResponse response = null;

            try
            {
                //设置最大连接数
                ServicePointManager.DefaultConnectionLimit = 200;
                //设置https验证方式
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                }

                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                //设置代理服务器
                //request.Proxy = new WebProxy() { Address = new Uri(WxPayConfig.PROXY_URL) };

                //获取服务器返回，处理返回
                response = (HttpWebResponse)request.GetResponse();
                if (!string.IsNullOrEmpty(response.ContentType) && response.ContentType.ToLower().Contains("text"))
                {
                    var respCharset = Encoding.UTF8;
                    if (!string.IsNullOrEmpty(response.CharacterSet))
                    {
                        respCharset = Encoding.GetEncoding(response.CharacterSet);
                    }
                    using (var sr = new StreamReader(response.GetResponseStream(), respCharset))
                    {
                        result = sr.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new WxPayException(ex.ToString());
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
                if (request != null)
                {
                    request.Abort();
                    request = null;
                }
            }
            return result;
        }
    }
}
