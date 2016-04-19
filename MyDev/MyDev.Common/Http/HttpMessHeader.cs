using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.Common.Http
{
    /// <summary>
    /// 常用头
    /// </summary>
    public class HttpGeneralHeader
    {
        private string _cacheControl = string.Empty;
        public string CacheControl
        {
            get { return this._cacheControl; }
            set { this._cacheControl = value; }
        }
        private string _connection = string.Empty;
        public string Connection
        {
            get { return this._connection; }
            set { this._connection = value; }
        }
        private string _date = string.Empty;
        public string Date
        {
            get { return this._date; }
            set { this._date = value; }
        }
        private string _pragma = string.Empty;
        public string Pragma
        {
            get { return this._pragma; }
            set { this._pragma = value; }
        }
        private string _trailer = string.Empty;
        public string Trailer
        {
            get { return this._trailer; }
            set { this._trailer = value; }
        }
        private string _transferEncoding = string.Empty;
        public string TransferEncoding
        {
            get { return this._transferEncoding; }
            set { this._transferEncoding = value; }
        }
        private string _upgrade = string.Empty;
        public string Upgrade
        {
            get { return this._upgrade; }
            set { this._upgrade = value; }
        }
        private string _via = string.Empty;
        public string Via
        {
            get { return this._via; }
            set { this._via = value; }
        }
        private string _warning = string.Empty;
        public string Warning
        {
            get { return this._warning; }
            set { this._warning = value; }
        }
    }
    /// <summary>
    /// 实体头
    /// </summary>
    public class HttpEntityHeader
    {
        private string _allow;
        public string Allow
        {
            get { return this._allow; }
            set { this._allow = value; }
        }
        private string _contentEncoding;
        public string ContentEncoding
        {
            get { return this._contentEncoding; }
            set { this._contentEncoding = value; }
        }
        private string _contentLanguage;
        public string ContentLanguage
        {
            get { return this._contentLanguage; }
            set { this._contentLanguage = value; }
        }
        private string _contentLength;
        public string ContentLength
        {
            get { return this._contentLength; }
            set { this._contentLength = value; }
        }
        private string _contentLocation;
        public string ContentLocation
        {
            get { return this._contentLocation; }
            set { this._contentLocation = value; }
        }
        private string _contentMd5;
        public string ContentMd5
        {
            get { return this._contentMd5; }
            set { this._contentMd5 = value; }
        }
        private string _contentRange;
        public string ContentRange
        {
            get { return this._contentRange; }
            set { this._contentRange = value; }
        }
        private string _contentType;
        public string ContentType
        {
            get { return this._contentType; }
            set { this._contentType = value; }
        }
        private string _expires;
        public string Expires
        {
            get { return this._expires; }
            set { this._expires = value; }
        }
        private string _lastModified;
        public string LastModified
        {
            get { return this._lastModified; }
            set { this._lastModified = value; }
        }

        private Dictionary<string, string> _extensionHeader = new Dictionary<string, string>();
        public Dictionary<string, string> ExtensionHeader
        {
            get { return this._extensionHeader; }
        }
    }

    /// <summary>
    /// 请求行
    /// </summary>
    public class HttpReqLine
    {
        private string _method = System.Net.Http.HttpMethod.Get.Method;
        public string Method
        {
            get { return this._method; }
            set { this._method = value; }
        }
        private string _reqUrl = string.Empty;
        public string ReqUrl
        {
            get { return this._reqUrl; }
            set { this._reqUrl = value; }
        }
        private string _httpVersion = System.Net.HttpVersion.Version11.ToString();
        public string HttpVersion
        {
            get { return this._httpVersion; }
            set { this._httpVersion = value; }
        }
    }
    /// <summary>
    /// 请求头
    /// </summary>
    public class HttpReqHeader
    {
        private string _accept="*/*";
        public string Accept
        {
            get { return this._accept; }
            set { this._accept = value; }
        }
        private string _acceptCharset = "ISO-8859-1";
        public string AcceptCharset
        {
            get { return this._acceptCharset; }
            set { this._acceptCharset = value; }
        }
        private string _acceptEncoding = string.Empty;
        public string AcceptEncoding
        {
            get { return this._acceptEncoding; }
            set { this._acceptEncoding = value; }
        }
        private string _acceptLanguage = string.Empty;
        public string AcceptLanguage
        {
            get { return this._acceptLanguage; }
            set { this._acceptLanguage = value; }
        }
        private string _authorization = string.Empty;
        public string Authorization
        {
            get { return this._authorization; }
            set { this._authorization = value; }
        }
        private string _expect = string.Empty;
        public string Expect
        {
            get { return this._expect; }
            set { this._expect = value; }
        }
        private string _from = string.Empty;
        public string From
        {
            get { return this._from; }
            set { this._from = value; }
        }
        private string _host = string.Empty;
        public string Host
        {
            get { return this._host; }
            set { this._host = value; }
        }
        private string _ifMatch = string.Empty;
        public string IfMatch
        {
            get { return this._ifMatch; }
            set { this._ifMatch = value; }
        }
        private string _ifModifiedSince = string.Empty;
        public string IfModifiedSince
        {
            get { return this._ifModifiedSince; }
            set { this._ifModifiedSince = value; }
        }
        private string _ifNoneMatch = string.Empty;
        public string IfNoneMatch
        {
            get { return this._ifNoneMatch; }
            set { this._ifNoneMatch = value; }
        }
        private string _ifRange = string.Empty;
        public string IfRange
        {
            get { return this._ifRange; }
            set { this._ifRange = value; }
        }
        private string _ifUnmodifiedSince = string.Empty;
        public string IfUnmodifiedSince
        {
            get { return this._ifUnmodifiedSince; }
            set { this._ifUnmodifiedSince = value; }
        }
        private string _maxForwards = string.Empty;
        public string MaxForwards
        {
            get { return this._maxForwards; }
            set { this._maxForwards = value; }
        }
        private string _proxyAuthorization = string.Empty;
        public string ProxyAuthorization
        {
            get { return this._proxyAuthorization; }
            set { this._proxyAuthorization = value; }
        }
        private string _range = string.Empty;
        public string Range
        {
            get { return this._range; }
            set { this._range = value; }
        }
        private string _referer = string.Empty;
        public string Referer
        {
            get { return this._referer; }
            set { this._referer = value; }
        }
        private string _te = string.Empty;
        public string Te
        {
            get { return this._te; }
            set { this._te = value; }
        }
        private string _userAgent = string.Empty;
        public string UserAgent
        {
            get { return this._userAgent; }
            set { this._userAgent = value; }
        }
    }

    /// <summary>
    /// 状态行
    /// </summary>
    public class HttpStatusLine
    {
        private string _httpVersion;
        public string HttpVersion
        {
            get { return this._httpVersion; }
            set { this._httpVersion = value; }
        }
        private string _statusCode;
        public string StatusCode
        {
            get { return this._statusCode; }
            set { this._statusCode = value; }
        }
        private string _reasonPhrase;
        public string ReasonPhrase
        {
            get { return this._reasonPhrase; }
            set { this._reasonPhrase = value; }
        }
    }
    /// <summary>
    /// 响应头
    /// </summary>
    public class HttpRespHeader
    {
        private string _acceptRanges;
        public string AcceptRanges
        {
            get { return this._acceptRanges; }
            set { this._acceptRanges = value; }
        }
        private string _age;
        public string Age
        {
            get { return this._age; }
            set { this._age = value; }
        }
        private string _eTag;
        public string ETag
        {
            get { return this._eTag; }
            set { this._eTag = value; }
        }
        private string _location;
        public string Location
        {
            get { return this._location; }
            set { this._location = value; }
        }
        private string _proxyAuthenticate;
        public string ProxyAuthenticate
        {
            get { return this._proxyAuthenticate; }
            set { this._proxyAuthenticate = value; }
        }
        private string _retryAfter;
        public string RetryAfter
        {
            get { return this._retryAfter; }
            set { this._retryAfter = value; }
        }
        private string _server;
        public string Server
        {
            get { return this._server; }
            set { this._server = value; }
        }
        private string _vary;
        public string Vary
        {
            get { return this._vary; }
            set { this._vary = value; }
        }
        private string _wwwAuthenticate;
        public string WwwAuthenticate
        {
            get { return this._wwwAuthenticate; }
            set { this._wwwAuthenticate = value; }
        }
    }
}
