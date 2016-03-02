using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.Api.WebApi.WebLogic
{
    public class JsonOrJsonpMediaTypeFormatter : JsonMediaTypeFormatter
    {
        private string _callback = "callback";
        public string Callback
        {
            get { return this._callback; }
            private set { this._callback = value; }
        }

        public JsonOrJsonpMediaTypeFormatter(string callback = null)
        {
            this._callback = callback;
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            if (string.IsNullOrEmpty(this._callback))
            {
                return base.WriteToStreamAsync(type, value, writeStream, content, transportContext);
            }
            try
            {
                this.WriteToStream(type, value, writeStream, content);
                return Task.FromResult<AsyncVoid>(new AsyncVoid());
            }
            catch (Exception exception)
            {
                TaskCompletionSource<AsyncVoid> source = new TaskCompletionSource<AsyncVoid>();
                source.SetException(exception);
                return source.Task;
            }
        }
        public void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        {
            JsonSerializer serializer = JsonSerializer.Create(this.SerializerSettings);
            using (StreamWriter streamWriter = new StreamWriter(writeStream, this.SupportedEncodings.First()))
            { 
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(streamWriter) { CloseOutput = false })
            {
                jsonTextWriter.WriteRaw(this._callback + "(");
                serializer.Serialize(jsonTextWriter, value);
                jsonTextWriter.WriteRaw(")");
            }
            }
        }

        public override MediaTypeFormatter GetPerRequestFormatterInstance(Type type, HttpRequestMessage request, MediaTypeHeaderValue mediaType)
        {
            if (request.Method != HttpMethod.Get)
            {
                return this;
            }
            string callback;
            if (request.GetQueryNameValuePairs().ToDictionary(pair => pair.Key, pair => pair.Value).TryGetValue(this._callback, out callback))
            {
                return new JsonOrJsonpMediaTypeFormatter(callback);
            }
            return this;
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        private struct AsyncVoid
        { }
    }
}
