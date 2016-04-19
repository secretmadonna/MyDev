using MyDev.Common;
using MyDev.Common.Http;
using MyDev.Common.PartnerApi.Tencent;
using MyDev.Common.PartnerApi.Tencent.Models;
using MyDev.Common.PartnerApi.Tencent.WxPay;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MyDev.UserInterface.Test.TestClass
{
    public class Program
    {
        public enum TestEnum
        {
            EnumValue1 = 1,
            EnumValue2 = 2,
            EnumValue3 = 3,
        }
        public struct TestStruct
        {
            public bool TestBool { get; set; }
            public int TestInt { get; set; }
            public string TestString { get; set; }
            public DateTime TestDateTime { get; set; }
        }
        public class TestSubClass
        {
            public bool TestBool { get; set; }
            public int TestInt { get; set; }
            public string TestString { get; set; }
            public DateTime TestDateTime { get; set; }
            public TestEnum TestEnum { get; set; }
            public TestStruct TestStruct { get; set; }
            public List<string> TestListString { get; set; }
        }
        public class TestClass
        {
            public bool? TestBool { get; set; }
            public bool ShouldSerializeTestBool()
            {
                return TestBool.HasValue;
            }
            public int? TestInt { get; set; }
            public bool ShouldSerializeTestInt()
            {
                return TestInt.HasValue;
            }
            public string TestString { get; set; }
            public bool ShouldSerializeTestString()
            {
                return TestString != null;
            }
            public DateTime? TestDateTime { get; set; }
            public bool ShouldSerializeTestDateTime()
            {
                return TestDateTime.HasValue;
            }
            [XmlIgnore]
            public TestEnum? TestEnum { get; set; }
            public bool ShouldSerializeTestEnum()
            {
                return TestEnum.HasValue;
            }
            public int? TestEnumInt
            {
                get
                {
                    if (TestEnum.HasValue)
                    {
                        return (int)TestEnum.Value;
                    }
                    return null;
                }
                set { TestEnum = (TestEnum?)value; }
            }
            public bool ShouldSerializeTestEnumInt()
            {
                return TestEnumInt.HasValue;
            }
            //public TestStruct TestStruct { get; set; }
            //public List<string> TestListString { get; set; }

            //public TestSubClass TestSubClass { get; set; }
        }

        public class Test
        {
            static void Main()
            {
                //Console.WriteLine("1234567897897897979878798789789798789789787987897878978978978797899787897897897897897897897897897987897777777777777777777777777777777777777777777777777777777777777777777777777777999".Length);
                //Console.WriteLine("哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈哈".Length);
                //var str = @"c:\fdsafk.eefe\3002\0.3\.25\0f///il.txt";

                ////System.IO.Path.

                //StringHelper.IsValidPath(str);

                //WxPayData data = new WxPayData();
                //data.SetValue("haha", "fsafasfdsa");
                //data.SetValue("haha", "dddddddddddd");
                //Console.WriteLine(data.GetValue("haha"));
                //Test t = new Test();
                //// Deserialize the file containing unknown attributes.

                //t.DeserializeObject(@".\UnknownAttributes.xml");





                TestClass c = new TestClass()
                {
                    TestBool = null,
                    TestInt = 0,
                    TestString = null,
                    TestDateTime = DateTime.Now,
                    TestEnum = null
                };

                var xml = TypeHelper.ToXml(c);
                var json = TypeHelper.ToJson(c);

                Console.WriteLine(xml);
                Console.WriteLine(json);

                Console.ReadKey();
            }

            //private void DeserializeObject(string filename)
            //{
            //    XmlSerializer ser = new XmlSerializer(typeof(Group));
            //    // A FileStream is needed to read the XML document.
            //    FileStream fs = new FileStream(filename, FileMode.Open);
            //    Group g = (Group)ser.Deserialize(fs);
            //    fs.Close();
            //    // Write out the data, including unknown attributes.
            //    Console.WriteLine(g.GroupName);
            //    Console.WriteLine("Number of unknown attributes: " +
            //    g.XAttributes.Length);
            //    foreach (XmlAttribute xAtt in g.XAttributes)
            //    {
            //        Console.WriteLine(xAtt.Name + ": " + xAtt.InnerXml);
            //    }
            //    // Serialize the object again with the attributes added.
            //    this.SerializeObject("AttributesAdded.xml", g);
            //}

            //private void SerializeObject(string filename, object g)
            //{
            //    XmlSerializer ser = new XmlSerializer(typeof(Group));
            //    TextWriter writer = new StreamWriter(filename);
            //    ser.Serialize(writer, g);
            //    writer.Close();
            //}
        }

        //    static void Main(string[] args)
        //    {
        //        //Console.WriteLine(TenHelper.GetAccessToken());

        //        //var strPath = @"\abc/abd\test.txt";
        //        //var realPath = string.Empty;
        //        //Console.WriteLine(IsValidPath(strPath, false));




        //        //var helper = new HttpHelper();

        //        //var httpParams = new HttpMessReqParameter();
        //        ////
        //        //httpParams.ReqLine.ReqUrl = "http://portal.mydev.com/TestAjax/GetJson";
        //        //httpParams.ReqLine.Method = "POST";
        //        ////
        //        //httpParams.EntityHeader = new HttpEntityHeader();
        //        //httpParams.EntityHeader.ContentType = "text/plain; charset=utf-8";
        //        ////
        //        //httpParams.EntityBody = new HttpEntityBody();
        //        //var data = new HttpEntityBody<DefaultData>();
        //        //data.Data = new DefaultData();
        //        //data.Data.NameValues = new System.Collections.Specialized.NameValueCollection();
        //        //data.Data.NameValues.Add("parmsData", "this is a json.");
        //        //httpParams.EntityBody.Data = data;

        //        ////httpParams.ReqLine.HttpVersion = "";
        //        //helper.InitRequest(httpParams);
        //        //var result = helper.GetResponse();
        //        //if (result != null && result.StatusLine != null && result.StatusLine.StatusCode == ((int)System.Net.HttpStatusCode.OK).ToString())
        //        //{

        //        //}
















        //        var ms = new MemoryStream();
        //        XmlSerializer xs = new XmlSerializer(typeof(TestClass));

        //        //TestClass model = new TestClass() { TestInt = 1, TestString = "hahaha", TestSubClasses = null };
        //        //XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        //        //namespaces.Add("", "");
        //        //xs.Serialize(ms, model, namespaces);
        //        //ms.Position = 0L;
        //        //var sr = new StreamReader(ms);
        //        //var str = sr.ReadToEnd();
        //        //sr.Close();
        //        //sr = null;
        //        //ms.Close();
        //        //ms = null;
        //        //Console.WriteLine(str);

        //        //ms = new MemoryStream();
        //        //XmlSerializer xs2 = new XmlSerializer(typeof(TestSubClass));
        //        //TestSubClass model2 = new TestSubClass() { /*TestInt = 1, TestString = "hahaha",*/ TestDateTime = DateTime.Now };
        //        ////XmlSerializerNamespaces 
        //        //xs2.Serialize(ms, model2);
        //        //ms.Position = 0L;
        //        //sr = new StreamReader(ms);
        //        //str = sr.ReadToEnd();
        //        //sr.Close();
        //        //sr = null;
        //        //ms.Close();
        //        //ms = null;
        //        //Console.WriteLine(str);

        //        //var model = new TestClass()
        //        //{
        //        //    TestInt = 1,
        //        //    TestString = "哈哈哈",
        //        //    TestSubClass=new TestSubClass() { TestDateTime=DateTime.Now},
        //        //    TestSubClasses = new List<string>() { "a", "b" }
        //        //};
        //        //Console.WriteLine(ObjectToXmlStr(model));

        //        var list = new List<TestClass>() { new TestClass()
        //        {
        //            TestInt = 1,
        //            TestString = "哈哈哈",
        //            TestSubClasses = new List<TestSubClass>()
        //            {
        //                new TestSubClass() { TestInt=null,TestString=null,TestDateTime=null},
        //                new TestSubClass() { TestInt=0,TestString=string.Empty,TestDateTime=DateTime.Now},
        //                new TestSubClass() { TestInt=1,TestString="hahaha",TestDateTime=DateTime.Now}
        //            }
        //        }
        //        //,new TestClass()
        //        //{
        //        //    TestInt = 2,
        //        //    TestString = "呵呵呵",
        //        //    TestSubClasses = new List<string>() { "c", "d" }
        //        //},new TestClass()
        //        //{
        //        //    TestInt = 3,
        //        //    TestString = "gagaga",
        //        //    TestSubClasses = new List<string>() { "e", "f" }
        //        //}
        //        };
        //        var dic = new Dictionary<string, string>();
        //        var model = new TestClass()
        //        {
        //            TestInt = 1,
        //            TestString = "哈哈哈",
        //            TestSubClass=new TestSubClass(),
        //            TestSubClasses = new List<TestSubClass>()
        //            {
        //                new TestSubClass() { TestInt=null,TestString=null,TestDateTime=null},
        //                new TestSubClass() { TestInt=0,TestString=string.Empty,TestDateTime=DateTime.Now},
        //                new TestSubClass() { TestInt=1,TestString="hahaha",TestDateTime=DateTime.Now}
        //            }//,Dic=null
        //        };

        //        Console.WriteLine(ObjectToXmlStr(model));


        //        var hashtable = new System.Collections.Hashtable();
        //        hashtable.GetHashCode();
        //        var a = 0;
        //        a.GetHashCode()

        //        Console.ReadKey();
        //    }

        //    public static string ObjectToXmlStr(object obj)
        //    {
        //        //if (obj == null)
        //        //{
        //        //    return null;
        //        //}
        //        var settings = new XmlWriterSettings();
        //        //去除xml声明<?xml version="1.0" encoding="utf-8"?>
        //        settings.OmitXmlDeclaration = true;
        //        settings.Encoding = Encoding.Default;
        //        settings.Indent = true;
        //        var ms = new MemoryStream();
        //        using (var writer = XmlWriter.Create(ms, settings))
        //        {
        //            //去除默认命名空间xmls:xsi和xmlns:xsd
        //            var ns = new XmlSerializerNamespaces();
        //            ns.Add("", "");
        //            var xs = new XmlSerializer(obj.GetType());
        //            xs.Serialize(writer, obj, ns);
        //        }
        //        return settings.Encoding.GetString(ms.ToArray());
        //    }
        //}





        //[SerializableAttribute]
        //[XmlRoot(ElementName = "xml", IsNullable = false)]
        //public class TestClass
        //{
        //    [XmlElement]
        //    public int TestInt { get; set; }
        //    //[XmlAnyElement()]
        //    public string TestString { get; set; }
        //    //public DateTime TestDateTime { get; set; }
        //    //public TestEnum TestEnum { get; set; }
        //    //public TestStruct TestStruct { get; set; }
        //    public TestSubClass TestSubClass { get; set; }
        //    //[XmlArray]
        //    //public TestSubClass[] TestSubClasses { get; set; }
        //    //[XmlArray("arrays")]
        //    //[XmlArrayItem("TestSubClass",typeof(int))]
        //    //[XmlArrayItem("array",Type =typeof(TestSubClass))]
        //    //[XmlIgnore]
        //    public List<TestSubClass> TestSubClasses { get; set; }

        //    //public string SerializeTestSubClasses { get; set; }

        //    //public Dictionary<string, string> Dic { get; set; }
        //}
        //public class TestSubClass//: TestClass
        //{
        //    public int? TestInt { get; set; }
        //    public bool ShouldSerializeTestInt()
        //    {
        //        return TestInt.HasValue;
        //    }
        //    public string TestString { get; set; }
        //    public bool ShouldSerializeTestString()
        //    {
        //        return !string.IsNullOrEmpty(TestString);
        //    }
        //    //[XmlArrayItem(ElementName = "a_{0}")]
        //    public DateTime? TestDateTime { get; set; }
        //    public bool ShouldSerializeTestDateTime()
        //    {
        //        return TestDateTime.HasValue;
        //    }
        //}
        //public enum TestEnum
        //{
        //    TestEnumValue1 = 1,
        //    TestEnumValue2 = 2,
        //    TestEnumValue3 = 3,
        //    TestEnumValue4 = 4,
        //}
        //public struct TestStruct
        //{
        //    public int TestInt { get; set; }
        //    public string TestString { get; set; }
        //    public DateTime TestDateTime { get; set; }
        //    public TestSubClass TestSubClass { get; set; }
        //    public IList<TestSubClass> TestSubClasses { get; set; }
        //}
    }
}
