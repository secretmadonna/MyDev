﻿using MyDev.BusinessLogic;
using MyDev.Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyDev.UserInterface.Test.TestClass
{
    public class Program
    {
        private static readonly string _absoluteDir = AppDomain.CurrentDomain.BaseDirectory;
        static void Main(string[] args)
        {
            #region 测试路径判断

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

            #endregion

            #region 测试上传文件

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

            #endregion

            #region 测试下载文件

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

            #region 微信相关测试

            //////////////////////////////////////
            ///////    微信相关测试    ///////////
            //////////////////////////////////////
            //var nonceStr = WxHelper.GenerateNonceStr();
            //var timeStamp = WxHelper.GetTimeStamp();
            //var url = "http://portal.mydev.com/WxPay/Index";
            //var sign = WxHelper.GetJssdkSign(nonceStr, timeStamp, url);
            //Console.WriteLine(sign);

            #endregion

            #region 多线程日志

            //var mainThread = Thread.CurrentThread.ManagedThreadId.ToString();
            //LogHelper.Write(LogType.Test, LogLevel.Info, mainThread);
            //for (int i = 1; i <= 5; i++)
            //{
            //    LogHelper.Write(LogType.Test, LogLevel.Info, mainThread + " : " + i.ToString());
            //    var task = new Task(() =>
            //    {
            //        var currentThread = Thread.CurrentThread.ManagedThreadId.ToString();
            //        LogHelper.Write(LogType.Test, LogLevel.Info, currentThread);
            //        for (int j = 0; j < 10; j++)
            //        {
            //            LogHelper.Write(LogType.Test, LogLevel.Info, currentThread + " : " + j.ToString());
            //        }
            //    });
            //    task.Start();
            //}

            //for (int i = 0; i < 20; i++)
            //{
            //    if (i % 2 == 0)
            //    {
            //        var tempThread = new Thread(new ParameterizedThreadStart(WriteLogMethod));
            //        tempThread.IsBackground = false;//后台线程和前台线程？
            //        tempThread.Start(i);
            //        var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " " + string.Format("启动参数线程,参数为:{0}.", i);
            //        LogHelper.Write(LogType.Test, info);
            //    }
            //    else
            //    {
            //        var tempThread = new Thread(new ThreadStart(WriteLogMethod));
            //        tempThread.IsBackground = false;
            //        tempThread.Start();
            //        var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " " + "启动无参数线程.";
            //        LogHelper.Write(LogType.Test, info);
            //    }
            //}

            #endregion

            #region 数据库

            //try
            //{
            //    var result = AccountBl.Login(new BusinessLogic.BusinessObject.LoginModel() { Username = "duanfei", Password = "123456" });
            //    Console.WriteLine(TypeHelper.ToJson(result));
            //}
            //catch (Exception ex)
            //{
            //    LogHelper.Write(LogType.Test, ex);
            //}

            #endregion

            #region 枚举

            //var e = (MyTestEnum)0.3;
            //e = (MyTestEnum)1;
            //e = (MyTestEnum)100;
            //var name = Enum.GetName(typeof(MyTestEnum), e);
            //Console.WriteLine(name);

            #endregion

            Console.ReadKey();
        }

        #region 多线程日志

        //public static void WriteLogMethod()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " " + string.Format("不带参线程{0},循环:{1}.", Thread.CurrentThread.ManagedThreadId, i);
        //        LogHelper.Write(LogType.Test, info);
        //    }
        //}
        //public static void WriteLogMethod(object content)
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        var info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " " + string.Format("带参线程{0},循环:{1},参数为:{2}.", Thread.CurrentThread.ManagedThreadId, i, content);
        //        LogHelper.Write(LogType.Test, info);
        //    }
        //}

        #endregion

        #region 枚举

        //public enum MyTestEnum
        //{
        //    One = 1,
        //    Two,
        //    Three,
        //    Four,
        //    Five
        //}

        #endregion
    }
}
