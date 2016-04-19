using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.Common.Http
{
    public class HttpMessReqParameter 
    {
        private HttpReqLine _reqLine = new HttpReqLine();
        /// <summary>
        /// 请求行
        /// </summary>
        public HttpReqLine ReqLine
        {
            get { return this._reqLine; }
        }

        private HttpGeneralHeader _generalHeader;
        /// <summary>
        /// 常用头
        /// </summary>
        public HttpGeneralHeader GeneralHeader
        {
            get { return this._generalHeader; }
            set { this._generalHeader = value; }
        }
        private HttpReqHeader _reqHeader;
        /// <summary>
        /// 请求头
        /// </summary>
        public HttpReqHeader ReqHeader
        {
            get { return this._reqHeader; }
            set { this._reqHeader = value; }
        }

        private HttpEntityHeader _entityHeader;
        /// <summary>
        /// 实体头
        /// </summary>
        public HttpEntityHeader EntityHeader
        {
            get { return this._entityHeader; }
            set { this._entityHeader = value; }
        }
        private HttpEntityBody _entityBody;
        /// <summary>
        /// 实体主体
        /// </summary>
        public HttpEntityBody EntityBody
        {
            get { return this._entityBody; }
            set { this._entityBody = value; }
        }
    }

    public class HttpMessRespResult
    {
        private HttpStatusLine _statusLine;
        /// <summary>
        /// 状态行
        /// </summary>
        public HttpStatusLine StatusLine
        {
            get { return this._statusLine; }
            /*private*/ set { this._statusLine = value; }
        }

        private HttpGeneralHeader _generalHeader;
        /// <summary>
        /// 常用头
        /// </summary>
        public HttpGeneralHeader GeneralHeader
        {
            get { return this._generalHeader; }
            /*private*/ set { this._generalHeader = value; }
        }
        private HttpRespHeader _respHeader;
        /// <summary>
        /// 响应头
        /// </summary>
        public HttpRespHeader RespHeader
        {
            get { return this._respHeader; }
            /*private*/ set { this._respHeader = value; }
        }

        private HttpEntityHeader _entityHeader;
        /// <summary>
        /// 实体头
        /// </summary>
        public HttpEntityHeader EntityHeader
        {
            get { return this._entityHeader; }
            /*private*/ set { this._entityHeader = value; }
        }
        private HttpEntityBody _entityBody;
        /// <summary>
        /// 实体主体
        /// </summary>
        public HttpEntityBody EntityBody
        {
            get { return this._entityBody; }
            /*private*/ set { this._entityBody = value; }
        }
    }
}
