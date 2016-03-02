using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyDev.Common
{
    public class LogHelper
    {
        private static object locker = new object();
        private static int timeout = 10000;
        private static Dictionary<string, object> lockers = new Dictionary<string, object>();
        public static bool Write(string logger, string level, string content)
        {
            if (string.IsNullOrEmpty(logger) || string.IsNullOrEmpty(content))
            {
                return false;
            }
            if (string.IsNullOrEmpty(level))
            {
                level = "info";
            }

            #region 获取写日志的文件

            bool lockToken = false;
            string filename = string.Empty;
            try
            {
                filename = Path.IsPathRooted(logger) ? logger : Path.Combine(Directory.GetCurrentDirectory() + logger);
                if (!lockers.ContainsKey(filename))
                {
                    Monitor.TryEnter(locker, timeout, ref lockToken);
                    if (!lockers.ContainsKey(filename))
                    {
                        if (!File.Exists(filename))
                        {
                            var dir = Path.GetDirectoryName(filename);
                            if (Directory.Exists(dir))
                            {
                                File.Create(filename).Close();
                            }
                            else
                            {
                                var directoryinfo = Directory.CreateDirectory(dir);
                                if (directoryinfo != null)
                                {
                                    File.Create(filename).Close();
                                }
                            }
                        }
                        lockers.Add(filename, new object());
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
                System.Console.ReadKey();
                return false;
            }
            finally
            {
                if (lockToken)
                {
                    Monitor.Exit(locker);
                }
            }

            #endregion

            #region 写日志

            lockToken = false;
            object lockObj = lockers[filename];
            try
            {
                Monitor.TryEnter(lockObj, timeout, ref lockToken);
                FileInfo fileinfo = new FileInfo(filename);
                using (var fs = fileinfo.OpenWrite())
                {
                    var sw = new StreamWriter(fs);
                    sw.BaseStream.Seek(0, SeekOrigin.End);
                    sw.Write(content);
                    sw.Flush();
                    sw.Close();
                }
                //Thread.Sleep(5000);//阻塞5s，模拟写日志过程
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (lockToken)
                {
                    Monitor.Exit(lockObj);
                }
            }

            #endregion
        }
    }
}
