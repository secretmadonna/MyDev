using System;
using System.Text;

namespace MyDev.Common
{
    public class LogHelper
    {
        public static void Write(LogType type, Exception ex)
        {
            var exStr = ExceptionToString(ex);
            Write(type, LogLevel.Error, exStr);
        }
        public static void Write(LogType type, string info)
        {
            Write(type, LogLevel.Info, info);
        }
        public static void Write(LogType type, LogLevel level, string message)
        {
            var logger = GetLogger(type);
            DoWrite(logger, level, message);
        }

        private static NLog.ILogger GetLogger(LogType type)
        {
            var name = Enum.GetName(typeof(LogType), type);
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("不支持的日志类型", "type");
            }
            return NLog.LogManager.GetLogger(name);
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

        private static string ExceptionToString(Exception ex)
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine(ex.Message);
            sb.AppendLine(ex.StackTrace);
            var innerEx = ex.InnerException;
            while (innerEx != null)
            {
                sb.AppendLine();
                sb.AppendLine(innerEx.Message);
                sb.AppendLine(innerEx.StackTrace);

                innerEx = innerEx.InnerException;
            }
            return sb.ToString();
        }
    }

    public enum LogType
    {
        /// <summary>
        /// Web
        /// </summary>
        Web = 1,
        /// <summary>
        /// App
        /// </summary>
        App,
        /// <summary>
        /// 微信
        /// </summary>
        Wx,
        /// <summary>
        /// 库
        /// </summary>
        Lib,
        /// <summary>
        /// 缓存
        /// </summary>
        Cache,
        /// <summary>
        /// 数据库
        /// </summary>
        Db,
        /// <summary>
        /// 微信支付
        /// </summary>
        Wxpay,
        /// <summary>
        /// 支付宝支付
        /// </summary>
        Alipay,
        /// <summary>
        /// 服务
        /// </summary>
        Srv,
        /// <summary>
        /// 测试
        /// </summary>
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
