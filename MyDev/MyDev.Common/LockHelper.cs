using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.Common
{
    public class LockHelper
    {
        private static object locker = new object();
        private static int timeout = 10000;
        private static Dictionary<string, object> lockers = new Dictionary<string, object>();
    }
}
