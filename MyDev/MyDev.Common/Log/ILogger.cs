using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.Common.Log
{
    public interface ILogger
    {
        /// <summary>
        /// 记录代码运行时间
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="action">所测试的代码块</param>
        /// <param name="fileName">日志文件名</param>
        void Logger_Timer(string message, Action action, string fileName);

        /// <summary>
        /// 记录代码运行时间，日志文件名以codeTime开头的时间戳
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="action">所测试的代码块</param>
        void Logger_Timer(string message, Action action);

        /// <summary>
        /// 记录代码运行异常
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="action">要添加try...catch的代码块</param>
        /// <param name="fileName">日志文件名</param>
        void Logger_Exception(string message, Action action, string fileName);

        /// <summary>
        /// 记录代码运行异常，日志文件名以Exception开头的时间戳
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="action">要添加try...catch的代码块</param>
        void Logger_Exception(string message, Action action);

        /// <summary>
        /// 将message记录到日志文件
        /// </summary>
        /// <param name="message"></param>
        void Logger_Info(string message);

        /// <summary>
        /// 将message记录到名为fileName的日志文件
        /// </summary>
        /// <param name="message"></param>
        /// <param name="fileName"></param>
        void Logger_Info(string message, string fileName);
    }
}
