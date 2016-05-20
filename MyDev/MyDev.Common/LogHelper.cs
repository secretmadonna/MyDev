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

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="logger">日志文件，必须存在</param>
        /// <param name="content">日志内容</param>
        /// <returns></returns>
        public static bool Write(string logger,string level, string content)
        {
            if (string.IsNullOrEmpty(logger) || !File.Exists(logger) || string.IsNullOrEmpty(content) )
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



        public static void Write(LogType type, LogLevel level, string message)
        {
            var logger = GetLogger(type);
            DoWrite(logger, level, message);
        }

        private static NLog.ILogger GetLogger(LogType type)
        {
            NLog.ILogger logger = null;
            switch (type)
            {
                case LogType.Web:
                    logger = NLog.LogManager.GetLogger("Web");
                    break;
                case LogType.App:
                    logger = NLog.LogManager.GetLogger("App");
                    break;
                case LogType.Wx:
                    logger = NLog.LogManager.GetLogger("WeiXin");
                    break;
                case LogType.Lib:
                    logger = NLog.LogManager.GetLogger("Library");
                    break;
                case LogType.Cache:
                    logger = NLog.LogManager.GetLogger("Cache");
                    break;
                case LogType.Db:
                    logger = NLog.LogManager.GetLogger("Database");
                    break;
                case LogType.Wxpay:
                    logger = NLog.LogManager.GetLogger("WeiXinPay");
                    break;
                case LogType.Alipay:
                    logger = NLog.LogManager.GetLogger("Alipay");
                    break;
                case LogType.Srv:
                    logger = NLog.LogManager.GetLogger("Service");
                    break;
                case LogType.Test:
                    logger = NLog.LogManager.GetLogger("Test");
                    break;
                default:
                    throw new ArgumentException("不支持的日志类型", "type");
            }
            return logger;
        }
        private static void DoWrite(NLog.ILogger logger, LogLevel level, string message)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    logger.Debug(message);
                    break;
                case LogLevel.Info:
                    logger.Info(message);
                    break;
                case LogLevel.Warn:
                    logger.Warn(message);
                    break;
                case LogLevel.Error:
                    logger.Error(message);
                    break;
                case LogLevel.Fatal:
                    logger.Fatal(message);
                    break;
                default:
                    throw new ArgumentException("不支持的日志级别", "level");
            }
        }
    }

    public enum LogType
    {
        Web = 1,
        App,
        Wx,
        Lib,
        Cache,
        Db,
        Wxpay,
        Alipay,
        Srv,
        Test
    }
    public enum LogLevel
    {
        Debug = 1,
        Info,
        Warn,
        Error,
        Fatal
    }
}
