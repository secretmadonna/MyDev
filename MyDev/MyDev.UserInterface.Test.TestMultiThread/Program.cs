using MyDev.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyDev.UserInterface.Test.TestMultiThread
{
    class Program
    {
        private static string logger = Path.Combine(System.Environment.CurrentDirectory, "LogFile", "TestMultiThread.txt");
        static void Main(string[] args)
        {
            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " " + "Main Begin." + "\r\n");

            for (int i = 0; i < 20; i++)
            {
                if (i % 2 == 0)
                {
                    var tempThread = new Thread(new ParameterizedThreadStart(WriteLogMethod));
                    tempThread.IsBackground = false;//后台线程和前台线程？
                    tempThread.Start(i);
                    LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " " + string.Format("启动参数线程,参数为:{0}.", i) + "\r\n");
                }
                else
                {
                    var tempThread = new Thread(new ThreadStart(WriteLogMethod));
                    tempThread.IsBackground = false;
                    tempThread.Start();
                    LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " " + "启动不参数线程." + "\r\n");
                }
            }

            //for (int i = 0; i < 20; i++)
            //{
            //    if (i % 2 == 0)
            //    {
            //        Task.Factory.StartNew(WriteLogMethod, i);
            //    }
            //    else
            //    {
            //        Task.Factory.StartNew(WriteLogMethod);
            //    }
            //}

            LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " " + "Main End." + "\r\n");
            Task.WaitAll();
        }

        public static void WriteLogMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " " + string.Format("不带参线程{0},循环:{1}.", Thread.CurrentThread.ManagedThreadId, i) + "\r\n");
            }
        }
        public static void WriteLogMethod(object content)
        {
            for (int i = 0; i < 10; i++)
            {
                LogHelper.Write(logger, null, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " " + string.Format("带参线程{0},循环:{1},参数为:{2}.", Thread.CurrentThread.ManagedThreadId, i, content) + "\r\n");
            }
        }
    }
}
