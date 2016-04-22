using MyDev.Common;
using MyDev.Common.PartnerApi.Tencent;
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
        private static readonly string _absoluteDir = AppDomain.CurrentDomain.BaseDirectory;
        static void Main(string[] args)
        {
            #region 测试

            //////////////////////////////////////
            ///////    测试路径判断    ///////////
            //////////////////////////////////////
            //var strlist = new List<string>();
            //strlist.Add(null);
            //strlist.Add(string.Empty);
            //strlist.Add(".");
            //strlist.Add(".\\");
            //strlist.Add("..");
            //strlist.Add("..\\");
            //strlist.Add("d:");
            //strlist.Add("d:\\");
            //strlist.Add("d:\\abc");
            //strlist.Add("d:\\abc\\");
            //strlist.Add("d:\\abc\\abc.txt");
            //strlist.Add("\\");
            //strlist.Add("\\.");
            //strlist.Add("\\.\\");
            //strlist.Add("\\..\\");
            //strlist.Add("\\..");
            //strlist.Add("\\abc");
            //strlist.Add("\\abc\\");
            //strlist.Add("\\abc\\abc.txt");
            //strlist.Add("abc");
            //strlist.Add("abc.txt");
            //strlist.Add("\\abc");
            //strlist.Add("\\abc.txt");
            //strlist.Add("abc\\");
            //strlist.Add("abc\\abc.txt");
            //strlist.Add("a<b>c");
            //strlist.Add("a<b>c\\a<b>c.txt");
            //foreach (var item in strlist)
            //{
            //    Console.WriteLine(FileHelper.IsValidPath(item) + "    " + item);
            //}
            //foreach (var item in strlist)
            //{
            //    var outPath = string.Empty;
            //    Console.WriteLine(FileHelper.IsValidRelativePath(item, _absoluteDir, out outPath) + "    " + item);
            //    Console.WriteLine("outPath：" + outPath);
            //}



            //////////////////////////////////////
            ///////    测试上传文件    ///////////
            //////////////////////////////////////
            //var upFileDir = Path.Combine(_absoluteDir, "upload");

            //var httpData = new HttpData();
            ////NameValue
            //httpData.NameValues.Add("Id", "1");
            ////NameFile
            //var picture = new HttpFile() { FileName = "QQ20160420182637.png", ContentType = "image/png", FileData = null };
            //using (var fileStream = new FileStream(Path.Combine(upFileDir, picture.FileName), FileMode.Open, FileAccess.Read))
            //{
            //    using (var br = new BinaryReader(fileStream))
            //    {
            //        br.BaseStream.Seek(0, SeekOrigin.Begin);
            //        picture.FileData = br.ReadBytes((int)br.BaseStream.Length);
            //    }
            //}
            //httpData.NameFiles.Add("Picture", picture);
            //httpData.NameFiles.Add("File", new HttpFile(Path.Combine(upFileDir, "QQ20160421164013.png")));

            //var response = HttpHelper.GetTextUsePost("http://portal.mydev.com/TestAjax/SaveFormData", httpData);

            //Console.WriteLine(response);



            //////////////////////////////////////
            ///////    测试下载文件    ///////////
            //////////////////////////////////////
            //var downFileDir = Path.Combine(_absoluteDir, "download");

            //var file = HttpHelper.GetFileUseGet("http://portal.mydev.com/TestAjax/GetResult");
            //if (file.SaveAs(downFileDir))
            //{
            //    Console.WriteLine(string.Format("文件保存到目录（{0}）下成功.", _absoluteDir));
            //}

            #endregion




            Console.ReadKey();
        }
    }
}
