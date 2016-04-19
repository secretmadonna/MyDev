using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.Common.Http
{
    public class HttpHelper
    {
        private HttpWebRequest request = null;
        private HttpWebResponse response = null;

        public void InitRequest(HttpMessReqParameter httpParams)
        {
            if (httpParams == null)
            {
                throw new ArgumentNullException("httpParams");
            }
            if (string.IsNullOrEmpty(httpParams.ReqLine.ReqUrl) || !httpParams.ReqLine.ReqUrl.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(null, "httpParams.ReqLine.ReqUrl");
            }
            if (httpParams.ReqLine.ReqUrl.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = RemoteCertificateValidation;
            }
            request = WebRequest.CreateHttp(httpParams.ReqLine.ReqUrl);
            request.ProtocolVersion = (string.IsNullOrEmpty(httpParams.ReqLine.HttpVersion) ? HttpVersion.Version11 : new Version(httpParams.ReqLine.HttpVersion));
            request.Method = (string.IsNullOrEmpty(httpParams.ReqLine.Method) ? HttpMethod.Get.Method : httpParams.ReqLine.Method);

            #region 常用头

            if (httpParams.GeneralHeader != null)
            {
                if (!string.IsNullOrEmpty(httpParams.GeneralHeader.CacheControl))
                {
                    //if (httpParams.GeneralHeader.CacheControl.IndexOf("no-cache", StringComparison.OrdinalIgnoreCase) > 0)
                    //{ }
                    //else if (httpParams.GeneralHeader.CacheControl.IndexOf("no-store", StringComparison.OrdinalIgnoreCase) > 0)
                    //{ }
                    //else if (httpParams.GeneralHeader.CacheControl.IndexOf("max-age", StringComparison.OrdinalIgnoreCase) > 0)
                    //{ }
                    //else if (httpParams.GeneralHeader.CacheControl.IndexOf("max-stale", StringComparison.OrdinalIgnoreCase) > 0)
                    //{ }
                    //else if (httpParams.GeneralHeader.CacheControl.IndexOf("min-fresh", StringComparison.OrdinalIgnoreCase) > 0)
                    //{ }
                    //else if (httpParams.GeneralHeader.CacheControl.IndexOf("no-transform", StringComparison.OrdinalIgnoreCase) > 0)
                    //{ }
                    //else if (httpParams.GeneralHeader.CacheControl.IndexOf("only-if-cached", StringComparison.OrdinalIgnoreCase) > 0)
                    //{ }
                    //else if (httpParams.GeneralHeader.CacheControl.IndexOf("cache-extension", StringComparison.OrdinalIgnoreCase) > 0)
                    //{ }
                    //else
                    //{
                    //    request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.Default);
                    //}
                    request.Headers.Add(HttpRequestHeader.CacheControl, httpParams.GeneralHeader.CacheControl);
                }
                if (!string.IsNullOrEmpty(httpParams.GeneralHeader.Connection))
                {
                    //request.Connection = httpParams.GeneralHeader.Connection;
                    request.Headers.Add(HttpRequestHeader.Connection, httpParams.GeneralHeader.Connection);
                }
                if (!string.IsNullOrEmpty(httpParams.GeneralHeader.Date))
                {
                    //request.Date = DateTime.Parse(httpParams.GeneralHeader.Date);
                    request.Headers.Add(HttpRequestHeader.Date, httpParams.GeneralHeader.Date);
                }
                if (!string.IsNullOrEmpty(httpParams.GeneralHeader.Pragma))
                {
                    request.Headers.Add(HttpRequestHeader.Pragma, httpParams.GeneralHeader.Pragma);
                }
                if (!string.IsNullOrEmpty(httpParams.GeneralHeader.Trailer))
                {
                    request.Headers.Add(HttpRequestHeader.Trailer, httpParams.GeneralHeader.Trailer);
                }
                if (!string.IsNullOrEmpty(httpParams.GeneralHeader.TransferEncoding))
                {
                    //request.TransferEncoding = httpParams.GeneralHeader.TransferEncoding;
                    request.Headers.Add(HttpRequestHeader.TransferEncoding, httpParams.GeneralHeader.TransferEncoding);
                }
                if (!string.IsNullOrEmpty(httpParams.GeneralHeader.Upgrade))
                {
                    request.Headers.Add(HttpRequestHeader.Upgrade, httpParams.GeneralHeader.Upgrade);
                }
                if (!string.IsNullOrEmpty(httpParams.GeneralHeader.Via))
                {
                    request.Headers.Add(HttpRequestHeader.Via, httpParams.GeneralHeader.Via);
                }
                if (!string.IsNullOrEmpty(httpParams.GeneralHeader.Warning))
                {
                    request.Headers.Add(HttpRequestHeader.Warning, httpParams.GeneralHeader.Warning);
                }
            }

            #endregion

            #region 请求头

            if (httpParams.ReqHeader != null)
            {
                if (!string.IsNullOrEmpty(httpParams.ReqHeader.Accept))
                {
                    //request.Accept = httpParams.ReqHeader.Accept;
                    request.Headers.Add(HttpRequestHeader.Accept, httpParams.ReqHeader.Accept);
                }
                if (!string.IsNullOrEmpty(httpParams.ReqHeader.AcceptCharset))
                {
                    request.Headers.Add(HttpRequestHeader.AcceptCharset, httpParams.ReqHeader.AcceptCharset);
                }
                if (!string.IsNullOrEmpty(httpParams.ReqHeader.AcceptEncoding))
                {
                    request.Headers.Add(HttpRequestHeader.AcceptEncoding, httpParams.ReqHeader.AcceptEncoding);
                }
                if (!string.IsNullOrEmpty(httpParams.ReqHeader.AcceptLanguage))
                {
                    request.Headers.Add(HttpRequestHeader.AcceptLanguage, httpParams.ReqHeader.AcceptLanguage);
                }
                if (!string.IsNullOrEmpty(httpParams.ReqHeader.Authorization))
                {
                    //request.AuthenticationLevel = AuthenticationLevel.None;
                    //request.PreAuthenticate = false;
                    //request.UnsafeAuthenticatedConnectionSharing = false;
                    request.Headers.Add(HttpRequestHeader.Authorization, httpParams.ReqHeader.Authorization);
                }
                if (!string.IsNullOrEmpty(httpParams.ReqHeader.Expect))
                {
                    request.Headers.Add(HttpRequestHeader.AcceptEncoding, httpParams.ReqHeader.AcceptEncoding);
                }
                if (!string.IsNullOrEmpty(httpParams.ReqHeader.From))
                {
                    request.Headers.Add(HttpRequestHeader.From, httpParams.ReqHeader.From);
                }
                if (!string.IsNullOrEmpty(httpParams.ReqHeader.Host))
                {
                    //request.Host = httpParams.ReqHeader.Host;
                    request.Headers.Add(HttpRequestHeader.Host, httpParams.ReqHeader.Host);
                }
                if (!string.IsNullOrEmpty(httpParams.ReqHeader.IfMatch))
                {
                    request.Headers.Add(HttpRequestHeader.IfMatch, httpParams.ReqHeader.IfMatch);
                }
                if (!string.IsNullOrEmpty(httpParams.ReqHeader.IfModifiedSince))
                {
                    //request.IfModifiedSince = DateTime.Parse(httpParams.ReqHeader.IfModifiedSince);
                    request.Accept = httpParams.ReqHeader.Accept;
                }
                if (!string.IsNullOrEmpty(httpParams.ReqHeader.IfNoneMatch))
                {
                    request.Headers.Add(HttpRequestHeader.IfNoneMatch, httpParams.ReqHeader.IfNoneMatch);
                }
                if (!string.IsNullOrEmpty(httpParams.ReqHeader.IfRange))
                {
                    request.Headers.Add(HttpRequestHeader.IfRange, httpParams.ReqHeader.IfRange);
                }
                if (!string.IsNullOrEmpty(httpParams.ReqHeader.IfUnmodifiedSince))
                {
                    request.Headers.Add(HttpRequestHeader.IfUnmodifiedSince, httpParams.ReqHeader.IfUnmodifiedSince);
                }
                if (!string.IsNullOrEmpty(httpParams.ReqHeader.MaxForwards))
                {
                    request.Headers.Add(HttpRequestHeader.MaxForwards, httpParams.ReqHeader.MaxForwards);
                }
                if (!string.IsNullOrEmpty(httpParams.ReqHeader.ProxyAuthorization))
                {
                    //request.Proxy = null;
                    request.Headers.Add(HttpRequestHeader.ProxyAuthorization, httpParams.ReqHeader.ProxyAuthorization);
                }
                if (!string.IsNullOrEmpty(httpParams.ReqHeader.Range))
                {
                    request.Headers.Add(HttpRequestHeader.Range, httpParams.ReqHeader.Range);
                }
                if (!string.IsNullOrEmpty(httpParams.ReqHeader.Referer))
                {
                    //request.Referer = httpParams.ReqHeader.Referer;
                    request.Headers.Add(HttpRequestHeader.Referer, httpParams.ReqHeader.Referer);
                }
                if (!string.IsNullOrEmpty(httpParams.ReqHeader.Te))
                {
                    request.Headers.Add(HttpRequestHeader.Te, httpParams.ReqHeader.Te);
                }
                if (!string.IsNullOrEmpty(httpParams.ReqHeader.UserAgent))
                {
                    //request.UserAgent = httpParams.ReqHeader.UserAgent;
                    request.Headers.Add(HttpRequestHeader.UserAgent, httpParams.ReqHeader.UserAgent);
                }
            }

            #endregion

            #region 实体头

            if (httpParams.EntityHeader != null)
            {
                if (!string.IsNullOrEmpty(httpParams.EntityHeader.Allow))
                {
                    //request.AllowAutoRedirect = false;
                    //request.AllowReadStreamBuffering = false;
                    //request.AllowWriteStreamBuffering = false;
                    request.Headers.Add(HttpRequestHeader.Allow, httpParams.EntityHeader.Allow);
                }
                if (!string.IsNullOrEmpty(httpParams.EntityHeader.ContentEncoding))
                {
                    request.Headers.Add(HttpRequestHeader.ContentEncoding, httpParams.EntityHeader.ContentEncoding);
                }
                if (!string.IsNullOrEmpty(httpParams.EntityHeader.ContentLanguage))
                {
                    request.Headers.Add(HttpRequestHeader.ContentLanguage, httpParams.EntityHeader.ContentLanguage);
                }
                if (!string.IsNullOrEmpty(httpParams.EntityHeader.ContentLength))
                {
                    //request.ContentLength = long.Parse(httpParams.EntityHeader.ContentLength);
                    request.Headers.Add(HttpRequestHeader.ContentLength, httpParams.EntityHeader.ContentLength);
                }
                if (!string.IsNullOrEmpty(httpParams.EntityHeader.ContentLocation))
                {
                    request.Headers.Add(HttpRequestHeader.ContentLocation, httpParams.EntityHeader.ContentLocation);
                }
                if (!string.IsNullOrEmpty(httpParams.EntityHeader.ContentMd5))
                {
                    request.Headers.Add(HttpRequestHeader.ContentMd5, httpParams.EntityHeader.ContentMd5);
                }
                if (!string.IsNullOrEmpty(httpParams.EntityHeader.ContentRange))
                {
                    request.Headers.Add(HttpRequestHeader.ContentRange, httpParams.EntityHeader.ContentRange);
                }
                if (!string.IsNullOrEmpty(httpParams.EntityHeader.ContentType))
                {
                    request.ContentType = httpParams.EntityHeader.ContentType;
                    //request.Headers.Add(HttpRequestHeader.ContentType, httpParams.EntityHeader.ContentType);
                }
                if (!string.IsNullOrEmpty(httpParams.EntityHeader.Expires))
                {
                    request.Headers.Add(HttpRequestHeader.Expires, httpParams.EntityHeader.Expires);
                }
                if (!string.IsNullOrEmpty(httpParams.EntityHeader.LastModified))
                {
                    request.Headers.Add(HttpRequestHeader.LastModified, httpParams.EntityHeader.LastModified);
                }
                if (httpParams.EntityHeader.ExtensionHeader != null && httpParams.EntityHeader.ExtensionHeader.Count > 0)
                {
                    foreach (var item in httpParams.EntityHeader.ExtensionHeader)
                    {
                        request.Headers.Add(item.Key, item.Value);
                    }
                }
            }

            #endregion

            #region 实体主体

            if (httpParams.EntityBody != null && httpParams.EntityBody.Data != null && request.Method == HttpMethod.Post.Method)
            {
                var data = httpParams.EntityBody.Data as HttpEntityBody<DefaultData>;
                if (data != null && data.Data != null)
                {
                    var encode = Encoding.Default;
                    if (httpParams.EntityHeader != null && !string.IsNullOrEmpty(httpParams.EntityHeader.ContentType))
                    {
                        var charsetIndex = httpParams.EntityHeader.ContentType.LastIndexOf("charset", StringComparison.OrdinalIgnoreCase);
                        if (charsetIndex > 0)
                        {
                            var charset = httpParams.EntityHeader.ContentType.Substring(charsetIndex).Replace(" ", "").Split('=').LastOrDefault();
                            if (!string.IsNullOrEmpty(charset))
                            {
                                var tempEncode = Encoding.GetEncoding(charset);
                                if (tempEncode != null)
                                {
                                    encode = tempEncode;
                                }
                            }
                        }
                    }

                    var line = "--";
                    var newLine = "\r\n";
                    var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");

                    var stream = new MemoryStream();
                    //
                    var tempStr = "Content-Type: " + request.ContentType + newLine
                        + newLine;
                    var tempByte = encode.GetBytes(tempStr);
                    stream.Write(tempByte, 0, tempByte.Length);
                    //
                    if (data.Data.NameValues != null)
                    {
                        var values = data.Data.NameValues;
                        foreach (string item in values.Keys)
                        {
                            tempStr = string.Format(line + boundary + newLine
                                + "Content-Disposition: form-data; name=\"{0}\";" + newLine
                                + newLine
                                + "{1}" + newLine, item, values[item]);
                            tempByte = encode.GetBytes(tempStr);
                            stream.Write(tempByte, 0, tempByte.Length);
                        }
                    }
                    if (data.Data.NameHttpFiles != null)
                    {
                        foreach (var item in data.Data.NameHttpFiles)
                        {
                            tempStr = string.Format(line + boundary + newLine
                                + "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"" + newLine
                                + "Content-Type: {2}" + newLine
                                + newLine, item.Key, item.Value.FileName, item.Value.ContentType);
                            tempByte = encode.GetBytes(tempStr);
                            stream.Write(tempByte, 0, tempByte.Length);
                            stream.Write(item.Value.FileData, 0, item.Value.FileData.Length);
                        }
                    }

                    request.ContentType = "multipart/form-data; boundary=" + boundary;
                    request.ContentLength = stream.Length;
                    request.KeepAlive = true;
                    var requestStream = request.GetRequestStream();
                    stream.Position = 0L;
                    stream.CopyTo(requestStream);
                    stream.Close();
                    requestStream.Close();
                }
            }

            #endregion

            //request.Accept = string.Empty;
            //request.AllowAutoRedirect = true;
            //request.AllowReadStreamBuffering = true;
            //request.AllowWriteStreamBuffering = true;
            //request.AuthenticationLevel = System.Net.Security.AuthenticationLevel.None;
            //request.AutomaticDecompression = DecompressionMethods.None;
            //request.CachePolicy = new System.Net.Cache.HttpRequestCachePolicy();
            //request.ClientCertificates = new System.Security.Cryptography.X509Certificates.X509CertificateCollection();
            //request.Connection = string.Empty;
            //request.ConnectionGroupName = string.Empty;
            //request.ContentLength = 0;
            //request.ContentType = string.Empty;
            //request.ContinueDelegate = null;
            //request.ContinueTimeout = 0;
            //request.CookieContainer = new CookieContainer();
            //request.Credentials = null;
            //request.Date = DateTime.Now;
            //request.Expect = string.Empty;
            //request.Headers = new WebHeaderCollection();
            //request.Host = string.Empty;
            //request.IfModifiedSince = DateTime.Now;
            //request.ImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.None;
            //request.KeepAlive = true;
            //request.MaximumAutomaticRedirections = 0;
            //request.MaximumResponseHeadersLength = 0;
            //request.MediaType = string.Empty;
            //request.Method = string.Empty;
            //request.Pipelined = false;
            //request.PreAuthenticate = true;
            //request.ProtocolVersion = new Version();
            //request.Proxy = null;
            //request.ReadWriteTimeout = 0;
            //request.Referer = string.Empty;
            //request.SendChunked = true;
            //request.ServerCertificateValidationCallback = null;
            //request.Timeout = 0;
            //request.TransferEncoding = string.Empty;
            //request.UnsafeAuthenticatedConnectionSharing = true;
            //request.UseDefaultCredentials = true;
            //request.UserAgent = string.Empty;
        }
        private bool RemoteCertificateValidation(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public HttpMessRespResult GetResponse()
        {
            var result = new HttpMessRespResult();
            if (request != null)
            {
                response = request.GetResponse() as HttpWebResponse;
                if (response != null)
                {
                    #region 状态行

                    result.StatusLine = new HttpStatusLine();
                    result.StatusLine.HttpVersion = response.ProtocolVersion.ToString();
                    result.StatusLine.StatusCode = ((int)response.StatusCode).ToString();
                    result.StatusLine.ReasonPhrase = response.StatusDescription;

                    #endregion

                    var tempStr = string.Empty;

                    var keys = response.Headers.AllKeys;
                    foreach (var item in keys)
                    {
                        //if (Enum.IsDefined(typeof(HttpResponseHeader), item))
                        //{
                        //    tempStr = response.Headers[item];
                        //    if (!string.IsNullOrEmpty(tempStr))
                        //    {
                        //        if(item)
                        //    }
                        //}
                    }

                    #region 常用头

                    result.GeneralHeader = new HttpGeneralHeader();
                    tempStr = response.Headers[HttpResponseHeader.CacheControl];
                    if (!string.IsNullOrEmpty(tempStr))
                    {
                        result.GeneralHeader.CacheControl = tempStr;
                    }
                    tempStr = response.Headers[HttpResponseHeader.Connection];
                    if (!string.IsNullOrEmpty(tempStr))
                    {
                        result.GeneralHeader.Connection = tempStr;
                    }
                    tempStr = response.Headers[HttpResponseHeader.Date];
                    if (!string.IsNullOrEmpty(tempStr))
                    {
                        result.GeneralHeader.Date = tempStr;
                    }
                    tempStr = response.Headers[HttpResponseHeader.Pragma];
                    if (!string.IsNullOrEmpty(tempStr))
                    {
                        result.GeneralHeader.Pragma = tempStr;
                    }
                    tempStr = response.Headers[HttpResponseHeader.Trailer];
                    if (!string.IsNullOrEmpty(tempStr))
                    {
                        result.GeneralHeader.Trailer = tempStr;
                    }
                    tempStr = response.Headers[HttpResponseHeader.TransferEncoding];
                    if (!string.IsNullOrEmpty(tempStr))
                    {
                        result.GeneralHeader.TransferEncoding = tempStr;
                    }
                    tempStr = response.Headers[HttpResponseHeader.Upgrade];
                    if (!string.IsNullOrEmpty(tempStr))
                    {
                        result.GeneralHeader.Upgrade = tempStr;
                    }
                    tempStr = response.Headers[HttpResponseHeader.Via];
                    if (!string.IsNullOrEmpty(tempStr))
                    {
                        result.GeneralHeader.Via = tempStr;
                    }
                    tempStr = response.Headers[HttpResponseHeader.Warning];
                    if (!string.IsNullOrEmpty(tempStr))
                    {
                        result.GeneralHeader.Warning = tempStr;
                    }

                    #endregion

                    #region 响应头

                    result.RespHeader = new HttpRespHeader();
                    tempStr = response.Headers[HttpResponseHeader.AcceptRanges];
                    if (!string.IsNullOrEmpty(tempStr))
                    {
                        result.RespHeader.AcceptRanges = tempStr;
                    }
                    tempStr = response.Headers[HttpResponseHeader.Age];
                    if (!string.IsNullOrEmpty(tempStr))
                    {
                        result.RespHeader.Age = tempStr;
                    }
                    tempStr = response.Headers[HttpResponseHeader.ETag];
                    if (!string.IsNullOrEmpty(tempStr))
                    {
                        result.RespHeader.ETag = tempStr;
                    }
                    tempStr = response.Headers[HttpResponseHeader.Location];
                    if (!string.IsNullOrEmpty(tempStr))
                    {
                        result.RespHeader.Location = tempStr;
                    }
                    tempStr = response.Headers[HttpResponseHeader.ProxyAuthenticate];
                    if (!string.IsNullOrEmpty(tempStr))
                    {
                        result.RespHeader.ProxyAuthenticate = tempStr;
                    }
                    tempStr = response.Headers[HttpResponseHeader.RetryAfter];
                    if (!string.IsNullOrEmpty(tempStr))
                    {
                        result.RespHeader.RetryAfter = tempStr;
                    }
                    tempStr = response.Headers[HttpResponseHeader.Server];
                    if (!string.IsNullOrEmpty(tempStr))
                    {
                        result.RespHeader.Server = tempStr;
                    }
                    tempStr = response.Headers[HttpResponseHeader.Vary];
                    if (!string.IsNullOrEmpty(tempStr))
                    {
                        result.RespHeader.Vary = tempStr;
                    }
                    tempStr = response.Headers[HttpResponseHeader.WwwAuthenticate];
                    if (!string.IsNullOrEmpty(tempStr))
                    {
                        result.RespHeader.WwwAuthenticate = tempStr;
                    }

                    #endregion

                    #region 实体头

                    result.EntityHeader = new HttpEntityHeader();
                    tempStr = response.Headers[HttpResponseHeader.Allow];
                    if (!string.IsNullOrEmpty(tempStr))
                    {
                        result.EntityHeader.Allow = tempStr;
                    }
                    tempStr = response.Headers[HttpResponseHeader.ContentEncoding];
                    if (!string.IsNullOrEmpty(tempStr))
                    {
                        result.EntityHeader.ContentEncoding = tempStr;
                    }
                    tempStr = response.Headers[HttpResponseHeader.ContentLanguage];
                    if (!string.IsNullOrEmpty(tempStr))
                    {
                        result.EntityHeader.ContentLanguage = tempStr;
                    }
                    tempStr = response.Headers[HttpResponseHeader.ContentLength];
                    if (!string.IsNullOrEmpty(tempStr))
                    {
                        result.EntityHeader.ContentLength = tempStr;
                    }
                    tempStr = response.Headers[HttpResponseHeader.ContentLocation];
                    if (!string.IsNullOrEmpty(tempStr))
                    {
                        result.EntityHeader.ContentLocation = tempStr;
                    }
                    tempStr = response.Headers[HttpResponseHeader.ContentMd5];
                    if (!string.IsNullOrEmpty(tempStr))
                    {
                        result.EntityHeader.ContentMd5 = tempStr;
                    }
                    tempStr = response.Headers[HttpResponseHeader.ContentRange];
                    if (!string.IsNullOrEmpty(tempStr))
                    {
                        result.EntityHeader.ContentRange = tempStr;
                    }
                    tempStr = response.Headers[HttpResponseHeader.ContentType];
                    if (!string.IsNullOrEmpty(tempStr))
                    {
                        result.EntityHeader.ContentType = tempStr;
                    }
                    tempStr = response.Headers[HttpResponseHeader.Expires];
                    if (!string.IsNullOrEmpty(tempStr))
                    {
                        result.EntityHeader.Expires = tempStr;
                    }
                    tempStr = response.Headers[HttpResponseHeader.LastModified];
                    if (!string.IsNullOrEmpty(tempStr))
                    {
                        result.EntityHeader.LastModified = tempStr;
                    }

                    //tempStr =
                    //    if (!string.IsNullOrEmpty(tempStr))
                    //{
                    //    result.EntityHeader.ExtensionHeader = tempStr;
                    //}

                    #endregion

                    #region 实体主体

                    //result.EntityBody = new HttpEntityBody<DefaultData>();
                    //result.EntityBody.Data
                    //tempStr = response.Headers[HttpResponseHeader.CacheControl];
                    //if (!string.IsNullOrEmpty(tempStr))
                    //{
                    //    result.GeneralHeader.CacheControl = tempStr;
                    //}
                    result.EntityBody = new HttpEntityBody();

                    var responseStream = response.GetResponseStream();
                    var stream = new MemoryStream();
                    responseStream.CopyTo(stream);
                    responseStream.Close();
                    response.Close();
                    response = null;
                    request.Abort();
                    request = null;
                    result.EntityBody.Data = stream.ToArray();
                    stream.Close();

                    #endregion
                }
            }
            return result;
        }
    }
}
