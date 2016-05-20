using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.BusinessLogic.Common
{
    public class BusResult
    {
        public int Code { get; set; }
        public string Summary { get; set; }
        public string Detail { get; set; }
        public dynamic Data { get; set; }
    }

    public class BusResult<T> : BusResult
    {
        new public T Data { get; set; }
    }
}
