using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MyDev.Common
{
    public class XmlHelper
    {
        public void CreateXML(string fileSavePath, string root = "root")
        {
            var xmlDoc = new XmlDocument();
            //设置文档属性
            var xmlDec = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDoc.AppendChild(xmlDec);
            //添加根节点
            var xmlEle = xmlDoc.CreateElement(root);
            xmlDoc.AppendChild(xmlEle);
            //保存文件
            xmlDoc.Save(fileSavePath);
        }
    }
}
