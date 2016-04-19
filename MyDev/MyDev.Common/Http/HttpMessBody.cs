using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.Common.Http
{
    /// <summary>
    /// 实体主体
    /// </summary>
    public class HttpEntityBody
    {
        private dynamic _data;
        public dynamic Data
        {
            get { return this._data; }
            set { this._data = value; }
        }
    }
    public class HttpEntityBody<T> : HttpEntityBody
    {
        new public T Data
        {
            get { return base.Data; }
            set { base.Data = value; }
        }
    }

    public class DefaultData
    {
        public NameValueCollection NameValues { get; set; }
        public Dictionary<string, HttpFile> NameHttpFiles { get; set; }
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
    }
}
