using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.Common
{
    public class HttpHelper
    {
        
        public static string Post(string url, byte[] data, bool isUseCert = false, int timeout = 6)
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







        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
        private static HttpWebResponse CreateGetHttpResponse(string url, int timeout, string userAgent, CookieCollection cookies)
        {
            HttpWebRequest request = null;
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            }
            request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";







            request.Accept = string.Empty;
            request.AllowAutoRedirect = true;
            request.AllowReadStreamBuffering = true;
            request.AllowWriteStreamBuffering = true;
            request.AuthenticationLevel = System.Net.Security.AuthenticationLevel.None;
            request.AutomaticDecompression = DecompressionMethods.None;
            request.CachePolicy = new System.Net.Cache.HttpRequestCachePolicy();
            request.ClientCertificates = new System.Security.Cryptography.X509Certificates.X509CertificateCollection();
            request.Connection = string.Empty;
            request.ConnectionGroupName = string.Empty;
            request.ContentLength = 0;
            request.ContentType = string.Empty;
            request.ContinueDelegate = null;
            request.ContinueTimeout = 0;
            request.CookieContainer = new CookieContainer();
            request.Credentials = null;
            request.Date = DateTime.Now;
            request.Expect = string.Empty;
            request.Headers = new WebHeaderCollection();
            request.Host = string.Empty;
            request.IfModifiedSince = DateTime.Now;
            request.ImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.None;
            request.KeepAlive = true;
            request.MaximumAutomaticRedirections = 0;
            request.MaximumResponseHeadersLength = 0;
            request.MediaType = string.Empty;
            request.Method = string.Empty;
            request.Pipelined = false;
            request.PreAuthenticate = true;
            request.ProtocolVersion = new Version();
            request.Proxy = null;
            request.ReadWriteTimeout = 0;
            request.Referer = string.Empty;
            request.SendChunked = true;
            request.ServerCertificateValidationCallback = null;
            request.Timeout = 0;
            request.TransferEncoding = string.Empty;
            request.UnsafeAuthenticatedConnectionSharing = true;
            request.UseDefaultCredentials = true;
            request.UserAgent = string.Empty;
















            //设置代理UserAgent和超时
            //request.UserAgent = userAgent;
            //request.Timeout = timeout;
            if (cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(cookies);
            }
            return request.GetResponse() as HttpWebResponse;
        }
        private static HttpWebResponse CreatePostHttpResponse(string url, byte[] data,Encoding dataEncode, int timeout, string userAgent, CookieCollection cookies)
        {
            HttpWebRequest request = null;
            //如果是发送HTTPS请求  
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            }
            request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            //设置代理UserAgent和超时
            //request.UserAgent = userAgent;
            //request.Timeout = timeout; 

            if (cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(cookies);
            }
            //发送POST数据  
            if (!(parameters == null || parameters.Count == 0))
            {
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                        i++;
                    }
                }
                byte[] data = Encoding.ASCII.GetBytes(buffer.ToString());
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            string[] values = request.Headers.GetValues("Content-Type");
            return request.GetResponse() as HttpWebResponse;
        }
    }
}
