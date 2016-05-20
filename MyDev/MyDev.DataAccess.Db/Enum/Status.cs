using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.DataAccess.Db.Enum
{
    public enum Status
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal = 1,
        /// <summary>
        /// 禁用
        /// </summary>
        Disable = -1
    }
    public enum UserStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal = 1,
        /// <summary>
        /// 禁用
        /// </summary>
        Disable = -1,
        /// <summary>
        /// 锁定
        /// </summary>
        Lock = -2
    }
}
