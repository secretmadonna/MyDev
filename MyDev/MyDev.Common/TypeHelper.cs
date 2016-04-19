using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MyDev.Common
{
    public class TypeHelper
    {
        /// <summary>
        /// Json序列化
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ToJson(object o)
        {
            if (o == null)
            {
                throw new ArgumentException("参数{0}不能是null或空", "o");
            }
            return JsonConvert.SerializeObject(o);
        }
        /// <summary>
        /// Json反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T JsonToObject<T>(string json)
        {
            if (json==null)
            {
                throw new ArgumentException("参数{0}不能是null或空", "json");
            }
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// xml序列化
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ToXml(object o)
        {
            if (o == null)
            {
                throw new ArgumentException("参数{0}不能是null或空", "o");
            }
            var settings = new XmlWriterSettings();
            //去除xml声明<?xml version="1.0" encoding="utf-8"?>
            settings.OmitXmlDeclaration = true;
            settings.Encoding = Encoding.Default;
            settings.Indent = true;
            using (var ms = new MemoryStream())
            {
                using (var writer = XmlWriter.Create(ms, settings))
                {
                    //去除默认命名空间xmls:xsi和xmlns:xsd
                    var ns = new XmlSerializerNamespaces();
                    ns.Add(string.Empty, string.Empty);
                    var xs = new XmlSerializer(o.GetType());
                    xs.Serialize(writer, o, ns);
                }
                return settings.Encoding.GetString(ms.ToArray());
            }
        }
        /// <summary>
        /// xml反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T XmlToObject<T>(string xml)
        {
            if (xml == null)
            {
                throw new ArgumentException("参数{0}不能是null或空", "xml");
            }
            var settings = new XmlReaderSettings();
            using (var ms = new MemoryStream())
            {
                T t = default(T);
                using (var reader = XmlReader.Create(ms, settings))
                {
                    var xs = new XmlSerializer(typeof(T));
                    var o = xs.Deserialize(reader);
                    t = (T)o;
                }
                return t;
            }
        }
    }
}
