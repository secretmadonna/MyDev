using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MyDev.Common.PartnerApi.Tencent.WxPay
{
    public class WxPayData
    {
        private SortedDictionary<string, object> _data = new SortedDictionary<string, object>();
        
        public bool HasSetValue(string key)
        {
            object obj = null;
            if (this._data.TryGetValue(key, out obj) && obj != null)
            {
                return true;
            }
            return false;
        }
        public void SetValue(string key, object value)
        {
            this._data[key] = value;
        }
        public object GetValue(string key)
        {
            object obj = null;
            this._data.TryGetValue(key, out obj);
            return obj;
        }
        public bool TryGetValue(string key, out object value)
        {
            value = null;
            if (this._data.TryGetValue(key, out value) && value != null)
            {
                return true;
            }
            return false;
        }

        #region url

        /// <summary>
        /// 不包含sign
        /// </summary>
        /// <returns></returns>
        private string ToUrl()
        {
            string result = string.Empty;
            foreach (var item in this._data)
            {
                if (item.Value == null)
                {
                    throw new WxPayException("WxPayData中" + item.Key + "的值为null");
                }
                if (item.Key != "sign" && item.Value.ToString() != string.Empty)
                {
                    result += item.Key + "=" + item.Value + "&";
                }
            }
            result = result.Trim('&');
            return result;
        }

        #endregion

        #region xml

        public string ToXml()
        {
            if (this._data.Count == 0)
            {
                throw new WxPayException("WxPayData中无数据");
            }
            string result = "<xml>";
            foreach (var item in this._data)
            {
                if (item.Value == null)
                {
                    throw new WxPayException("WxPayData中" + item.Key + "的值为null");
                }
                if (item.Value.GetType() == typeof(int))
                {
                    result += "<" + item.Key + ">" + item.Value + "</" + item.Key + ">";
                }
                else if (item.Value.GetType() == typeof(string))
                {
                    result += "<" + item.Key + ">" + "<![CDATA[" + item.Value + "]]></" + item.Key + ">";
                }
                else
                {
                    throw new WxPayException("WxPayData中" + item.Key + "的数据类型错误");
                }
            }
            result += "</xml>";
            return result;
        }

        public SortedDictionary<string, object> FromXml(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                throw new WxPayException("不能将null或空的字符串转换WxPayData");
            }
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            var node = xmlDoc.FirstChild;
            var nodelist = node.ChildNodes;
            foreach (var item in nodelist)
            {
                var ele = (XmlElement)item;
                this._data[ele.Name] = ele.InnerText;
            }
            if (this._data["return_code"].ToString() == "SUCCESS")
            {
                CheckSign();
            }
            return this._data;
        }

        #endregion

        #region 生成签名、验证签名

        /// <summary>
        /// 生成签名
        /// </summary>
        /// <returns></returns>
        public string MakeSign(string encryptionAlgorithm = "MD5")
        {
            string urlParam = this.ToUrl();
            urlParam += "&key=" + WxPayConfig.KEY;
            var result = string.Empty;
            if (encryptionAlgorithm.ToLower() == "md5")
            {
                var md5 = MD5.Create();
                var tempBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(urlParam));
                var sb = new StringBuilder();
                foreach (byte b in tempBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                result = sb.ToString().ToUpper();
            }
            else if (encryptionAlgorithm.ToLower() == "")
            {
                result = string.Empty;
            }
            else
            {
                result = string.Empty;
            }
            return result;
        }
        /// <summary>
        /// 验证签名
        /// </summary>
        /// <returns></returns>
        public bool CheckSign()
        {
            var sign = "sign";
            object signValue = null;
            string signValueStr = string.Empty;
            if (!this.HasSetValue(sign))
            {
                throw new WxPayException("WxPayData无签名");
            }
            else if ((signValue = this.GetValue(sign)) == null)
            {
                throw new WxPayException("WxPayData签名值为null");
            }
            else if ((signValueStr = signValue.ToString()) == string.Empty)
            {
                throw new WxPayException("WxPayData签名值为空");
            }
            var newSignValueStr = this.MakeSign();
            if (newSignValueStr == signValueStr)
            {
                return true;
            }
            return false;
        }

        #endregion

        public SortedDictionary<string, object> GetData()
        {
            return this._data;
        }
    }
}
