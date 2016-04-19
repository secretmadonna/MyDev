using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.Common
{
    public class HttpHelper
    {
        /// <summary>
        /// HTTP通用头
        /// </summary>
        public class HttpCommonHeader
        {
            private string _cacheControl = "no-cache";
            /// <summary>
            /// 请求时，缓存指令包括no-cache、no-store、max-age、 max-stale、min-fresh、only-if-cached
            /// no-cache      ：指示请求不能缓存，实际上是可以存储在本地缓存区中的，只是在与原始服务器进行新鲜度验证之前，缓存不能将其提供给客户端使用。　
            /// no-store      ：缓存应该尽快从存储器中删除文档的所有痕迹，因为其中可能会包含敏感信息。
            /// max-age       ：缓存无法返回缓存时间长于max-age规定秒的文档，若不超规定秒浏览器将不会发送对应的请求到服务器，数据由缓存直接返回；超过这一时间段才进一步由服务器决定是返回新数据还是仍由缓存提供。若同时还发送了max-stale指令，则使用期可能会超过其过期时间。
            /// max-stale     ：指示客户端可以接收过期响应消息，如果指定max-stale消息的值，那么客户端可以接收过期但在指定值之内的响应消息。
            /// min-fresh     ：至少在未来规定秒内文档要保持新鲜，接受其新鲜生命期大于其当前 Age 跟 min-fresh 值之和的缓存对象。
            /// only-if-cached：只有当缓存中有副本存在时，客户端才会获得一份副本。
            /// 响应时，缓存指令包括public、private、no-cache、no- store、no-transform、must-revalidate、proxy-revalidate、max-age
            /// public          ：指示响应可被任何缓存区缓存，可以用缓存内容回应任何用户。
            /// private         ：指示对于单个用户的整个或部分响应消息，不能被共享缓存处理，只能用缓存内容回应先前请求该内容的那个用户。
            /// no-cache        ：指示请求不能缓存，实际上是可以存储在本地缓存区中的，只是在与原始服务器进行新鲜度验证之前，缓存不能将其提供给客户端使用。　
            /// no-store        ：缓存应该尽快从存储器中删除文档的所有痕迹，因为其中可能会包含敏感信息。
            /// no-transform    ：
            /// must-revalidate ：
            /// proxy-revalidate：
            /// max-age         ：
            /// </summary>
            public string CacheControl
            {
                get { return this._cacheControl; }
                set { this._cacheControl = value; }
            }
            private string _pragma = "no-cache";
            /// <summary>
            /// 在HTTP/1.1协议中，它的含义和Cache-Control:no-cache相同。
            /// </summary>
            public string Pragma
            {
                get { return this._pragma; }
                set { this._pragma = value; }
            }
            private string _connection = "no-cache";
            /// <summary>
            /// Close：告诉WEB服务器或者代理服务器，在完成本次请求的响应后，断开连接，不要等待本次连接的后续请求了。
            /// Keepalive：告诉WEB服务器或者代理服务器，在完成本次请求的响应后，保持连接，等待本次连接的后续请求。
            /// </summary>
            public string Connection
            {
                get { return this._pragma; }
                set { this._pragma = value; }
            }
        }

        /// <summary>
        /// 配置请求
        /// </summary>
        public class HttpReqConfig
        {
            private string _httpUrl = string.Empty;
            public string HttpUrl
            {
                get { return this._httpUrl; }
                set { this._httpUrl = value; }
            }
            private string _httpMethod = System.Net.Http.HttpMethod.Get.Method;
            public string HttpMethod
            {
                get { return this._httpMethod; }
                set { this._httpMethod = value; }
            }
            private Version _httpVersion = System.Net.HttpVersion.Version11;
            public Version HttpVersion
            {
                get { return this._httpVersion; }
                set { this._httpVersion = value; }
            }


        }
        /// <summary>
        /// HTTP请求头
        /// </summary>
        public class HttpReqHeader
        {
            private string _accept = string.Empty;
            /// <summary>
            /// 我可以接受的MIME类型（类型/子类型）
            /// */*表示任何类型
            /// </summary>
            public string Accept
            {
                get { return this._accept; }
                set { this._accept = value; }
            }







































            int _Timeout = 100000;
            /// <summary>  
            /// 默认请求超时时间  
            /// </summary>  
            public int Timeout
            {
                get { return _Timeout; }
                set { _Timeout = value; }
            }
            int _ReadWriteTimeout = 30000;
            /// <summary>  
            /// 默认写入Post数据超时间  
            /// </summary>  
            public int ReadWriteTimeout
            {
                get { return _ReadWriteTimeout; }
                set { _ReadWriteTimeout = value; }
            }
            Boolean _KeepAlive = true;
            /// <summary>  
            ///  获取或设置一个值，该值指示是否与 Internet 资源建立持久性连接默认为true。  
            /// </summary>  
            public Boolean KeepAlive
            {
                get { return _KeepAlive; }
                set { _KeepAlive = value; }
            }
            string _Accept = "text/html, application/xhtml+xml, */*";
            /// <summary>  
            /// 请求标头值 默认为text/html, application/xhtml+xml, */*  
            /// </summary>  
            public string Accept
            {
                get { return _Accept; }
                set { _Accept = value; }
            }
            string _ContentType = "text/html";
            /// <summary>  
            /// 请求返回类型默认 text/html  
            /// </summary>  
            public string ContentType
            {
                get { return _ContentType; }
                set { _ContentType = value; }
            }
            string _UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
            /// <summary>  
            /// 客户端访问信息默认Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)  
            /// </summary>  
            public string UserAgent
            {
                get { return _UserAgent; }
                set { _UserAgent = value; }
            }
            Encoding _Encoding = null;
            /// <summary>  
            /// 返回数据编码默认为NUll,可以自动识别,一般为utf-8,gbk,gb2312  
            /// </summary>  
            public Encoding Encoding
            {
                get { return _Encoding; }
                set { _Encoding = value; }
            }
            private PostDataType _PostDataType = PostDataType.String;
            /// <summary>  
            /// Post的数据类型  
            /// </summary>  
            public PostDataType PostDataType
            {
                get { return _PostDataType; }
                set { _PostDataType = value; }
            }
            string _Postdata = string.Empty;
            /// <summary>  
            /// Post请求时要发送的字符串Post数据  
            /// </summary>  
            public string Postdata
            {
                get { return _Postdata; }
                set { _Postdata = value; }
            }
            private byte[] _PostdataByte = null;
            /// <summary>  
            /// Post请求时要发送的Byte类型的Post数据  
            /// </summary>  
            public byte[] PostdataByte
            {
                get { return _PostdataByte; }
                set { _PostdataByte = value; }
            }
            private WebProxy _WebProxy;
            /// <summary>  
            /// 设置代理对象，不想使用IE默认配置就设置为Null，而且不要设置ProxyIp  
            /// </summary>  
            public WebProxy WebProxy
            {
                get { return _WebProxy; }
                set { _WebProxy = value; }
            }

            CookieCollection cookiecollection = null;
            /// <summary>  
            /// Cookie对象集合  
            /// </summary>  
            public CookieCollection CookieCollection
            {
                get { return cookiecollection; }
                set { cookiecollection = value; }
            }
            string _Cookie = string.Empty;
            /// <summary>  
            /// 请求时的Cookie  
            /// </summary>  
            public string Cookie
            {
                get { return _Cookie; }
                set { _Cookie = value; }
            }
            string _Referer = string.Empty;
            /// <summary>  
            /// 来源地址，上次访问地址  
            /// </summary>  
            public string Referer
            {
                get { return _Referer; }
                set { _Referer = value; }
            }
            string _CerPath = string.Empty;
            /// <summary>  
            /// 证书绝对路径  
            /// </summary>  
            public string CerPath
            {
                get { return _CerPath; }
                set { _CerPath = value; }
            }
            private Boolean isToLower = false;
            /// <summary>  
            /// 是否设置为全文小写，默认为不转化  
            /// </summary>  
            public Boolean IsToLower
            {
                get { return isToLower; }
                set { isToLower = value; }
            }
            private Boolean allowautoredirect = false;
            /// <summary>  
            /// 支持跳转页面，查询结果将是跳转后的页面，默认是不跳转  
            /// </summary>  
            public Boolean Allowautoredirect
            {
                get { return allowautoredirect; }
                set { allowautoredirect = value; }
            }
            private int connectionlimit = 1024;
            /// <summary>  
            /// 最大连接数  
            /// </summary>  
            public int Connectionlimit
            {
                get { return connectionlimit; }
                set { connectionlimit = value; }
            }
            private string proxyusername = string.Empty;
            /// <summary>  
            /// 代理Proxy 服务器用户名  
            /// </summary>  
            public string ProxyUserName
            {
                get { return proxyusername; }
                set { proxyusername = value; }
            }
            private string proxypwd = string.Empty;
            /// <summary>  
            /// 代理 服务器密码  
            /// </summary>  
            public string ProxyPwd
            {
                get { return proxypwd; }
                set { proxypwd = value; }
            }
            private string proxyip = string.Empty;
            /// <summary>  
            /// 代理 服务IP ,如果要使用IE代理就设置为ieproxy  
            /// </summary>  
            public string ProxyIp
            {
                get { return proxyip; }
                set { proxyip = value; }
            }
            private ResultType resulttype = ResultType.String;
            /// <summary>  
            /// 设置返回类型String和Byte  
            /// </summary>  
            public ResultType ResultType
            {
                get { return resulttype; }
                set { resulttype = value; }
            }
            private WebHeaderCollection header = new WebHeaderCollection();
            /// <summary>  
            /// header对象  
            /// </summary>  
            public WebHeaderCollection Header
            {
                get { return header; }
                set { header = value; }
            }

            private Version _ProtocolVersion;

            /// <summary>  
            //     获取或设置用于请求的 HTTP 版本。返回结果:用于请求的 HTTP 版本。默认为 System.Net.HttpVersion.Version11。  
            /// </summary>  
            public Version ProtocolVersion
            {
                get { return _ProtocolVersion; }
                set { _ProtocolVersion = value; }
            }
            private Boolean _expect100continue = true;
            /// <summary>  
            ///  获取或设置一个 System.Boolean 值，该值确定是否使用 100-Continue 行为。如果 POST 请求需要 100-Continue 响应，则为 true；否则为 false。默认值为 true。  
            /// </summary>  
            public Boolean Expect100Continue
            {
                get { return _expect100continue; }
                set { _expect100continue = value; }
            }
            private X509CertificateCollection _ClentCertificates;
            /// <summary>  
            /// 设置509证书集合  
            /// </summary>  
            public X509CertificateCollection ClentCertificates
            {
                get { return _ClentCertificates; }
                set { _ClentCertificates = value; }
            }
            private Encoding _PostEncoding;
            /// <summary>  
            /// 设置或获取Post参数编码,默认的为Default编码  
            /// </summary>  
            public Encoding PostEncoding
            {
                get { return _PostEncoding; }
                set { _PostEncoding = value; }
            }
            private ResultCookieType _ResultCookieType = ResultCookieType.String;
            /// <summary>  
            /// Cookie返回类型,默认的是只返回字符串类型  
            /// </summary>  
            public ResultCookieType ResultCookieType
            {
                get { return _ResultCookieType; }
                set { _ResultCookieType = value; }
            }

            private ICredentials _ICredentials = CredentialCache.DefaultCredentials;
            /// <summary>  
            /// 获取或设置请求的身份验证信息。  
            /// </summary>  
            public ICredentials ICredentials
            {
                get { return _ICredentials; }
                set { _ICredentials = value; }
            }
            /// <summary>  
            /// 设置请求将跟随的重定向的最大数目  
            /// </summary>  
            private int _MaximumAutomaticRedirections;

            public int MaximumAutomaticRedirections
            {
                get { return _MaximumAutomaticRedirections; }
                set { _MaximumAutomaticRedirections = value; }
            }

            private DateTime? _IfModifiedSince = null;
            /// <summary>  
            /// 获取和设置IfModifiedSince，默认为当前日期和时间  
            /// </summary>  
            public DateTime? IfModifiedSince
            {
                get { return _IfModifiedSince; }
                set { _IfModifiedSince = value; }
            }
        }
        /// <summary>
        /// HTTP请求体
        /// </summary>
        public class HttpReqContent
        { }
        /// <summary>
        /// HTTP相应
        /// </summary>
        public class HttpRespResult
        {
            private string _statusCode;
            public string StatusCode
            {
                get { return this._statusCode; }
                set { this._statusCode = value; }
            }
            private string _statusDescription;
            public string StatusDescription
            {
                get { return this._statusDescription; }
                set { this._statusDescription = value; }
            }
        }

        /// <summary>
        /// HTTP相应头
        /// </summary>
        public class HttpRespHeader
        { }
        /// <summary>
        /// HTTP实体头
        /// </summary>
        public class HttpEntityHeader
        { }
        /// <summary>
        /// HTTP相应体
        /// </summary>
        public class HttpRespContent
        { }
    }
}
