using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.Api.WebApiLogic.Cors
{
    public static class HttpRequestMessageExtensions
    {
        public static bool IsPreflightRequest(this HttpRequestMessage request)
        {
            return ((request.Method == HttpMethod.Options)
                && request.Headers.GetValues("Origin").Any()
                && request.Headers.GetValues("Access-Control-Request-Method").Any());
        }
    }
}
