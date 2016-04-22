using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.Common
{
    public class HttpData
    {
        private Encoding _dataEncode = Encoding.UTF8;
        public Encoding DataEncode
        {
            get { return this._dataEncode; }
            set { this._dataEncode = value; }
        }
        private Dictionary<string, string> _nameValues = new Dictionary<string, string>();
        public Dictionary<string, string> NameValues
        {
            get { return this._nameValues; }
            //set { this._nameValues = value; }
        }
        private Dictionary<string, HttpFile> _nameFiles = new Dictionary<string, HttpFile>();
        public Dictionary<string, HttpFile> NameFiles
        {
            get { return this._nameFiles; }
            //set { this._nameFiles = value; }
        }
    }
    public class HttpFile
    {
        private string _fileName;
        public string FileName
        {
            get { return this._fileName; }
            set { this._fileName = value; }
        }
        private byte[] _fileData;
        public byte[] FileData
        {
            get { return this._fileData; }
            set { this._fileData = value; }
        }
        private string _contentType = "application/octet-stream";
        public string ContentType
        {
            get { return this._contentType; }
            set { this._contentType = value; }
        }

        public HttpFile() { }

        public HttpFile(string path)
        {
            if (File.Exists(path))
            {
                this.FileName = Path.GetFileName(path);
                this.ContentType = FileHelper.GetMimeMapping(Path.GetExtension(path));
                using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    using (var br = new BinaryReader(fileStream))
                    {
                        br.BaseStream.Seek(0, SeekOrigin.Begin);
                        this.FileData = br.ReadBytes((int)br.BaseStream.Length);
                    }
                }
            }
        }

        /// <summary>
        /// 保存到目录下
        /// </summary>
        /// <param name="dir">绝对路径(目录)</param>
        /// <param name="createDir"></param>
        /// <param name="overwrite"></param>
        /// <returns></returns>
        public bool SaveAs(string dir)
        {
            try
            {
                var name = dir.TrimEnd('\\') + "\\" + this.FileName;
                if (FileHelper.SaveAs(this.FileData, name, true, true) > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                //记录日志
            }
            return false;
        }
    }
    class HttpWebReqAndResp
    {
        public HttpWebRequest request { get; set; }
        public HttpWebResponse response { get; set; }
    }

    public class HttpHelper
    {
        #region GET

        public static string GetTextUseGet(string url
            , string accept = null, string userAgent = null, int timeout = 100
            , bool useCert = false, string certFile = null, string certPassword = null
            , CookieContainer cookieContainer = null, ICredentials credentials = null, IWebProxy proxy = null
            , Dictionary<string, string> otherHeader = null)
        {
            var result = string.Empty;

            var reqAndResp = new HttpWebReqAndResp();
            try
            {
                reqAndResp = CreateGetHttpResponse(url, accept, userAgent, timeout, useCert, certFile, certPassword, cookieContainer, credentials, proxy, otherHeader);
                if (reqAndResp != null && reqAndResp.request != null && reqAndResp.response != null
                    && reqAndResp.response.StatusCode == HttpStatusCode.OK
                    && reqAndResp.response.ContentLength > 0
                    && (reqAndResp.response.ContentType.StartsWith("text", StringComparison.OrdinalIgnoreCase)
                    || reqAndResp.response.ContentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase)
                    || reqAndResp.response.ContentType.StartsWith("application/xml", StringComparison.OrdinalIgnoreCase)))
                {
                    var encode = Encoding.UTF8;
                    if (!string.IsNullOrEmpty(reqAndResp.response.CharacterSet))
                    {
                        encode = Encoding.GetEncoding(reqAndResp.response.CharacterSet);
                    }
                    using (var responseStream = reqAndResp.response.GetResponseStream())
                    {
                        using (var sr = new StreamReader(responseStream, encode))
                        {
                            result = sr.ReadToEnd();
                        }
                    }
                }
            }
            finally
            {
                if (reqAndResp != null)
                {
                    if (reqAndResp.response != null)
                    {
                        reqAndResp.response.Close();
                        reqAndResp.response = null;
                    }
                    if (reqAndResp.request != null)
                    {
                        reqAndResp.request.Abort();
                        reqAndResp.request = null;
                    }
                    reqAndResp = null;
                }
            }

            return result;
        }

        public static HttpFile GetFileUseGet(string url
            , string accept = null, string userAgent = null, int timeout = 100
            , bool useCert = false, string certFile = null, string certPassword = null
            , CookieContainer cookieContainer = null, ICredentials credentials = null, IWebProxy proxy = null
            , Dictionary<string, string> otherHeader = null)
        {
            HttpFile result = new HttpFile();

            var reqAndResp = new HttpWebReqAndResp();
            try
            {
                reqAndResp = CreateGetHttpResponse(url, accept, userAgent, timeout, useCert, certFile, certPassword, cookieContainer, credentials, proxy, otherHeader);
                if (reqAndResp != null && reqAndResp.request != null && reqAndResp.response != null
                    && reqAndResp.response.StatusCode == HttpStatusCode.OK
                    && reqAndResp.response.ContentLength > 0
                    && (reqAndResp.response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase)
                    || reqAndResp.response.ContentType.StartsWith("audio", StringComparison.OrdinalIgnoreCase)
                    || reqAndResp.response.ContentType.StartsWith("video", StringComparison.OrdinalIgnoreCase)
                    || reqAndResp.response.ContentType.StartsWith("application/octet-stream", StringComparison.OrdinalIgnoreCase)))
                {
                    result.ContentType = reqAndResp.response.ContentType;
                    result.FileName = Guid.NewGuid().ToString("N") + FileHelper.GetExtension(result.ContentType);
                    using (var responseStream = reqAndResp.response.GetResponseStream())
                    {
                        using (var ms = new MemoryStream())
                        {
                            responseStream.CopyTo(ms);
                            result.FileData = ms.ToArray();
                        }
                        //using (var sr = new BinaryReader(responseStream))
                        //{
                        //    sr.ReadBytes((int)sr.BaseStream.Length);
                        //}
                    }
                }
            }
            finally
            {
                if (reqAndResp != null)
                {
                    if (reqAndResp.response != null)
                    {
                        reqAndResp.response.Close();
                        reqAndResp.response = null;
                    }
                    if (reqAndResp.request != null)
                    {
                        reqAndResp.request.Abort();
                        reqAndResp.request = null;
                    }
                    reqAndResp = null;
                }
            }

            return result;
        }

        private static HttpWebReqAndResp CreateGetHttpResponse(string url
            , string accept = null, string userAgent = null, int timeout = 100
            , bool useCert = false, string certFile = null, string certPassword = null
            , CookieContainer cookieContainer = null, ICredentials credentials = null, IWebProxy proxy = null
            , Dictionary<string, string> otherHeader = null)
        {
            //垃圾回收，回收没有正常关闭的http连接
            System.GC.Collect();

            //设置最大连接数
            ServicePointManager.DefaultConnectionLimit = 200;
            //设置https验证方式
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            }

            var request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.Accept = accept;
            request.UserAgent = userAgent;
            if (otherHeader != null && otherHeader.Count > 0)
            {
                foreach (var item in otherHeader)
                {
                    request.Headers.Add(item.Key, item.Value);
                }
            }

            request.Timeout = timeout * 1000;

            //是否使用证书
            if (useCert && !string.IsNullOrEmpty(certFile) && !string.IsNullOrEmpty(certPassword))
            {
                request.ClientCertificates.Add(new X509Certificate2(certFile, certPassword));
            }
            if (cookieContainer != null)
            {
                request.CookieContainer = cookieContainer;
            }
            if (credentials != null)
            {
                request.Credentials = credentials;
            }
            if (proxy != null)
            {
                request.Proxy = proxy;
            }
            //设置请求是否应跟随重定向响应
            //request.AllowAutoRedirect = allowAutoRedirect;
            //request.AllowReadStreamBuffering = true;//是否对从 Internet 资源接收的数据进行缓冲处理
            //request.AllowWriteStreamBuffering = true;//是否对发送到 Internet 资源的数据进行缓冲处理
            //request.AuthenticationLevel = System.Net.Security.AuthenticationLevel.None;
            //request.AutomaticDecompression = DecompressionMethods.None;
            //request.CachePolicy = new System.Net.Cache.HttpRequestCachePolicy(System.Net.Cache.HttpRequestCacheLevel.Default);
            //request.Connection = null;
            //request.ConnectionGroupName = null;
            //request.ContentLength = 0;
            //request.ContentType = null;
            //request.ContinueDelegate = null;
            //request.ContinueTimeout = 0;
            //request.Date = DateTime.Now;
            //request.Expect = null;
            //request.Host;
            //request.IfModifiedSince = DateTime.Now;
            //request.ImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.None;
            //request.KeepAlive = true;
            //request.MaximumAutomaticRedirections = 50;
            //request.MaximumResponseHeadersLength = HttpWebRequest.DefaultMaximumResponseHeadersLength;
            //request.MediaType = null;
            //request.Pipelined = true;
            //request.PreAuthenticate = false;
            //request.ProtocolVersion = HttpVersion.Version11;
            //request.ReadWriteTimeout = 300000;
            //request.Referer = null;
            //request.SendChunked = false;
            //request.ServerCertificateValidationCallback;
            //request.TransferEncoding = null;
            //request.UnsafeAuthenticatedConnectionSharing;
            //request.UseDefaultCredentials = false;
            HttpWebResponse response = null;
            try
            {
                response = request.GetResponse() as HttpWebResponse;
            }
            catch (Exception ex)
            {
                //记录日志？？？
            }

            return new HttpWebReqAndResp() { request = request, response = response };
        }

        #endregion

        #region POST

        public static string GetTextUsePost(string url, HttpData data
            , string accept = null, string userAgent = null, int timeout = 100
            , bool useCert = false, string certFile = null, string certPassword = null
            , CookieContainer cookieContainer = null, ICredentials credentials = null, IWebProxy proxy = null
            , Dictionary<string, string> otherHeader = null)
        {
            var result = string.Empty;

            var reqAndResp = new HttpWebReqAndResp();
            try
            {
                reqAndResp = CreatePostHttpResponse(url, data, accept, userAgent, timeout, useCert, certFile, certPassword, cookieContainer, credentials, proxy, otherHeader);
                if (reqAndResp != null && reqAndResp.request != null && reqAndResp.response != null
                    && reqAndResp.response.StatusCode == HttpStatusCode.OK
                    && reqAndResp.response.ContentLength > 0
                    && (reqAndResp.response.ContentType.StartsWith("text", StringComparison.OrdinalIgnoreCase)
                    || reqAndResp.response.ContentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase)
                    || reqAndResp.response.ContentType.StartsWith("application/xml", StringComparison.OrdinalIgnoreCase)))
                {
                    var encode = Encoding.UTF8;
                    if (!string.IsNullOrEmpty(reqAndResp.response.CharacterSet))
                    {
                        encode = Encoding.GetEncoding(reqAndResp.response.CharacterSet);
                    }
                    using (var responseStream = reqAndResp.response.GetResponseStream())
                    {
                        using (var sr = new StreamReader(responseStream, encode))
                        {
                            result = sr.ReadToEnd();
                        }
                    }
                }
            }
            finally
            {
                if (reqAndResp != null)
                {
                    if (reqAndResp.response != null)
                    {
                        reqAndResp.response.Close();
                        reqAndResp.response = null;
                    }
                    if (reqAndResp.request != null)
                    {
                        reqAndResp.request.Abort();
                        reqAndResp.request = null;
                    }
                    reqAndResp = null;
                }
            }

            return result;
        }

        public static HttpFile GetFileUsePost(string url, HttpData data
            , string accept = null, string userAgent = null, int timeout = 100
            , bool useCert = false, string certFile = null, string certPassword = null
            , CookieContainer cookieContainer = null, ICredentials credentials = null, IWebProxy proxy = null
            , Dictionary<string, string> otherHeader = null)
        {
            HttpFile result = new HttpFile();

            var reqAndResp = new HttpWebReqAndResp();
            try
            {
                reqAndResp = CreatePostHttpResponse(url, data, accept, userAgent, timeout, useCert, certFile, certPassword, cookieContainer, credentials, proxy, otherHeader);
                if (reqAndResp != null && reqAndResp.request != null && reqAndResp.response != null
                    && reqAndResp.response.StatusCode == HttpStatusCode.OK
                    && reqAndResp.response.ContentLength > 0
                    && (reqAndResp.response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase)
                    || reqAndResp.response.ContentType.StartsWith("audio", StringComparison.OrdinalIgnoreCase)
                    || reqAndResp.response.ContentType.StartsWith("video", StringComparison.OrdinalIgnoreCase)
                    || reqAndResp.response.ContentType.StartsWith("application/octet-stream", StringComparison.OrdinalIgnoreCase)))
                {
                    result.ContentType = reqAndResp.response.ContentType;
                    result.FileName = Guid.NewGuid().ToString("N") + FileHelper.GetExtension(result.ContentType);
                    using (var responseStream = reqAndResp.response.GetResponseStream())
                    {
                        using (var ms = new MemoryStream())
                        {
                            responseStream.CopyTo(ms);
                            result.FileData = ms.ToArray();
                        }
                        //using (var br = new BinaryReader(responseStream))
                        //{
                        //    result.FileData = br.ReadBytes((int)br.BaseStream.Length);
                        //}
                    }
                }
            }
            finally
            {
                if (reqAndResp != null)
                {
                    if (reqAndResp.response != null)
                    {
                        reqAndResp.response.Close();
                        reqAndResp.response = null;
                    }
                    if (reqAndResp.request != null)
                    {
                        reqAndResp.request.Abort();
                        reqAndResp.request = null;
                    }
                    reqAndResp = null;
                }
            }

            return result;
        }

        private static HttpWebReqAndResp CreatePostHttpResponse(string url, HttpData data
            , string accept = null, string userAgent = null, int timeout = 100
            , bool useCert = false, string certFile = null, string certPassword = null
            , CookieContainer cookieContainer = null, ICredentials credentials = null, IWebProxy proxy = null
            , Dictionary<string, string> otherHeader = null)
        {
            //垃圾回收，回收没有正常关闭的http连接
            System.GC.Collect();

            //设置最大连接数
            ServicePointManager.DefaultConnectionLimit = 200;
            //设置https验证方式
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            }

            var request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.Accept = accept;
            request.UserAgent = userAgent;
            request.KeepAlive = true;
            if (otherHeader != null && otherHeader.Count > 0)
            {
                foreach (var item in otherHeader)
                {
                    request.Headers.Add(item.Key, item.Value);
                }
            }

            request.Timeout = timeout * 1000;

            //是否使用证书
            if (useCert && !string.IsNullOrEmpty(certFile) && !string.IsNullOrEmpty(certPassword))
            {
                request.ClientCertificates.Add(new X509Certificate2(certFile, certPassword));
            }
            if (cookieContainer != null)
            {
                request.CookieContainer = cookieContainer;
            }
            if (credentials != null)
            {
                request.Credentials = credentials;
            }
            if (proxy != null)
            {
                request.Proxy = proxy;
            }

            byte[] ByteList;
            using (var stream = new MemoryStream())
            {
                if (data != null && data.DataEncode != null && data.NameFiles.Count > 0)
                {
                    var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
                    request.ContentType = "multipart/form-data; boundary=" + boundary;

                    var line = "--";
                    var newLine = "\r\n";

                    //
                    var tempStr = "Content-Type: " + request.ContentType + newLine
                        + newLine;
                    var tempByte = data.DataEncode.GetBytes(tempStr);
                    stream.Write(tempByte, 0, tempByte.Length);
                    //
                    if (data.NameValues.Count > 0)
                    {
                        foreach (var item in data.NameValues)
                        {
                            tempStr = string.Format(line + boundary + newLine
                                    + "Content-Disposition: form-data; name=\"{0}\";" + newLine
                                    + newLine
                                    + "{1}" + newLine, item.Key, item.Value);
                            tempByte = data.DataEncode.GetBytes(tempStr);
                            stream.Write(tempByte, 0, tempByte.Length);
                        }
                    }
                    //
                    if (data.NameFiles.Count > 0)
                    {
                        foreach (var item in data.NameFiles)
                        {
                            if (item.Value != null)
                            {
                                tempStr = string.Format(line + boundary + newLine
                                        + "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"" + newLine
                                        + "Content-Type: {2}" + newLine
                                        + newLine, item.Key, item.Value.FileName, item.Value.ContentType);
                            }
                            else
                            {
                                tempStr = string.Format(line + boundary + newLine
                                        + "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"" + newLine
                                        + "Content-Type: {2}" + newLine
                                        + newLine
                                        + newLine, item.Key, string.Empty, "application/octet-stream");
                            }
                            tempByte = data.DataEncode.GetBytes(tempStr);
                            stream.Write(tempByte, 0, tempByte.Length);
                            if (item.Value != null)
                            {
                                stream.Write(item.Value.FileData, 0, item.Value.FileData.Length);
                                tempStr = newLine;
                                tempByte = data.DataEncode.GetBytes(tempStr);
                                stream.Write(tempByte, 0, tempByte.Length);
                            }
                        }
                    }
                    //
                    tempStr = line + boundary + line + newLine
                        + newLine;
                    tempByte = data.DataEncode.GetBytes(tempStr);
                    stream.Write(tempByte, 0, tempByte.Length);
                }
                else if (data != null && data.DataEncode != null && data.NameValues.Count > 0)
                {
                    request.ContentType = "application/x-www-form-urlencoded";
                    var sb = new StringBuilder();
                    foreach (var item in data.NameValues)
                    {
                        sb.Append(string.Format("{0}={1}&", item.Key, item.Value));
                    }
                    var tempStr = sb.ToString().TrimEnd('&');
                    var tempByte = data.DataEncode.GetBytes(tempStr);
                    stream.Write(tempByte, 0, tempByte.Length);
                }
                ByteList = stream.ToArray();
            }
            request.ContentLength = ByteList.Length;

            //将数据写入请求流
            using (var reqStream = request.GetRequestStream())
            {
                reqStream.Write(ByteList, 0, ByteList.Length);
            }


            HttpWebResponse response = null;
            try
            {
                response = request.GetResponse() as HttpWebResponse;
            }
            catch (Exception)
            {
                //记录日志？？？
            }

            return new HttpWebReqAndResp() { request = request, response = response };
        }

        #endregion

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
    }
}
