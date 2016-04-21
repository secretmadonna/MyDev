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
        /// <summary>
        /// 写日志的根目录
        /// 如果提供的路径不是绝对路径，是相对路径，就是相对于该“绝对目录”的路径
        /// </summary>
        private static readonly string _absoluteDir = AppDomain.CurrentDomain.BaseDirectory;

        private static object locker = new object();
        private static int timeout = 10000;
        private static Dictionary<string, object> lockers = new Dictionary<string, object>();

        public static bool Write(string logger, string level, string content)
        {
            if (string.IsNullOrEmpty(logger) || string.IsNullOrEmpty(level) || string.IsNullOrEmpty(content))
            {
                return false;
            }

            #region 获取写日志的文件

            bool lockToken = false;
            string logFile = string.Empty;//文件路径（绝对路径）
            try
            {
                logFile = Path.IsPathRooted(logger) ? logger : Path.Combine(_absoluteDir, logger);
                if (!lockers.ContainsKey(logFile))
                {
                    Monitor.TryEnter(locker, timeout, ref lockToken);
                    if (!lockers.ContainsKey(logFile))
                    {
                        if (File.Exists(logFile))
                        {
                            lockers.Add(logFile, new object());
                        }
                        else
                        {
                            var tempDir = Path.GetDirectoryName(logFile);
                            if (Directory.Exists(tempDir))
                            {
                                File.Create(logFile).Close();
                            }
                            else
                            {
                                if (Directory.CreateDirectory(tempDir) != null)
                                {
                                    File.Create(logFile).Close();
                                }
                            }
                        }
                        lockers.Add(logFile, new object());
                    }
                }
            }
            catch
            {
                //如何处理异常
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
            object lockObj = lockers[logFile];
            try
            {
                Monitor.TryEnter(lockObj, timeout, ref lockToken);
                FileInfo fileinfo = new FileInfo(logFile);
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
            catch
            {
                //如何处理异常
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
