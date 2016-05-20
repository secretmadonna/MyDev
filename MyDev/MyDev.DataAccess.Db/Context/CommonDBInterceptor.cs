using MyDev.Common;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.DataAccess.Db.Context
{
    public class CommonDBInterceptor : DbCommandInterceptor
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();

        /// <summary>
        /// 执行时间超过此值将被记录
        /// </summary>
        const int infoValue = 200 * 1000;
        /// <summary>
        /// 执行时间超过此值将被发出警告
        /// </summary>
        const int warnValue = 500 * 1000;

        /// <summary>
        /// select
        /// </summary>
        /// <param name="command"></param>
        /// <param name="interceptionContext"></param>
        public override void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            base.ScalarExecuting(command, interceptionContext);
            _stopwatch.Start();
        }
        public override void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            _stopwatch.Stop();
            //Trace.WriteLine("Scalar : " + _stopwatch.ElapsedTicks);
            if (_stopwatch.ElapsedTicks >= infoValue && _stopwatch.ElapsedTicks < warnValue)
            {
                LogHelper.Write(LogType.Db, LogLevel.Info, "Reader : " + command.CommandText);
            }
            else if (_stopwatch.ElapsedTicks >= warnValue)
            {
                LogHelper.Write(LogType.Db, LogLevel.Warn, "Reader : " + command.CommandText);
            }
            _stopwatch.Reset();
            base.ScalarExecuted(command, interceptionContext);
        }

        /// <summary>
        /// update,delete
        /// </summary>
        /// <param name="command"></param>
        /// <param name="interceptionContext"></param>
        public override void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            base.NonQueryExecuting(command, interceptionContext);
            _stopwatch.Start();
        }
        public override void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            _stopwatch.Stop();
            //Trace.WriteLine("NonQuery : " + _stopwatch.ElapsedTicks);
            if (_stopwatch.ElapsedTicks >= infoValue && _stopwatch.ElapsedTicks < warnValue)
            {
                LogHelper.Write(LogType.Db, LogLevel.Info, "Reader : " + command.CommandText);
            }
            else if (_stopwatch.ElapsedTicks >= warnValue)
            {
                LogHelper.Write(LogType.Db, LogLevel.Warn, "Reader : " + command.CommandText);
            }
            _stopwatch.Reset();
            base.NonQueryExecuted(command, interceptionContext);
        }

        /// <summary>
        /// select,insert
        /// </summary>
        /// <param name="command"></param>
        /// <param name="interceptionContext"></param>
        public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            base.ReaderExecuting(command, interceptionContext);
            _stopwatch.Start();
        }
        public override void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            _stopwatch.Stop();
            if (_stopwatch.ElapsedTicks >= infoValue && _stopwatch.ElapsedTicks < warnValue)
            {
                LogHelper.Write(LogType.Db, LogLevel.Info, "Reader : " + command.CommandText);
            }
            else if (_stopwatch.ElapsedTicks >= warnValue)
            {
                LogHelper.Write(LogType.Db, LogLevel.Warn, "Reader : " + command.CommandText);
            }
            _stopwatch.Reset();
            base.ReaderExecuted(command, interceptionContext);
        }
    }
}
