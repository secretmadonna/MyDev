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
        const int traceValue = 200;
        /// <summary>
        /// 执行时间超过此值将被发出警告
        /// </summary>
        const int warningValue = 500;

        public override void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            _stopwatch.Start();
            base.ScalarExecuting(command, interceptionContext);
        }
        public override void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            base.ScalarExecuted(command, interceptionContext);
            _stopwatch.Stop();
            Trace.WriteLine("Scalar : " + _stopwatch.ElapsedTicks);
            _stopwatch.Reset();
        }

        public override void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            _stopwatch.Start();
            base.NonQueryExecuting(command, interceptionContext);
        }
        public override void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            base.NonQueryExecuted(command, interceptionContext);
            _stopwatch.Stop();
            Trace.WriteLine("NonQuery : " + _stopwatch.ElapsedTicks);
            _stopwatch.Reset();
        }

        public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            _stopwatch.Start();
            base.ReaderExecuting(command, interceptionContext);
        }
        public override void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            base.ReaderExecuted(command, interceptionContext);
            _stopwatch.Stop();
            Trace.WriteLine("Reader : " + _stopwatch.ElapsedTicks);
            _stopwatch.Reset();
        }
    }
}
