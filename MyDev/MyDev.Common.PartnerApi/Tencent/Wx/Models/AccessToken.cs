using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.Common.PartnerApi.Tencent.Wx.Models
{
    /// <summary>
    /// 接口调用凭证（access_token）
    /// 公众号调用各接口时，都需要使用 access_token
    /// access_token 是公众号的全局唯一票据
    /// </summary>
    public class AccessTokenModel
    {
        [JsonProperty(PropertyName = "errcode")]
        public int? ErrorCode { get; set; }
        [JsonProperty(PropertyName = "errmsg")]
        public string ErrorMessage { get; set; }
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }
        [JsonProperty(PropertyName = "expires_in")]
        public int? ExpiresIn { get; set; }
    }
    public class JsapiTicketModel
    {
        [JsonProperty(PropertyName = "errcode")]
        public int? ErrorCode { get; set; }
        [JsonProperty(PropertyName = "errmsg")]
        public string ErrorMessage { get; set; }
        [JsonProperty(PropertyName = "ticket")]
        public string Ticket { get; set; }
        [JsonProperty(PropertyName = "expires_in")]
        public int? ExpiresIn { get; set; }
    }
}
