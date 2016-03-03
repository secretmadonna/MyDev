using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.DataAccess.Db.Enum
{
    public enum Access
    {
        /// <summary>
        /// 不需要登录，即可访问
        /// </summary>
        NotNeedLogin = 1,
        /// <summary>
        /// 需要登录，才能访问
        /// </summary>
        NeedLogin,
        /// <summary>
        /// 需要具备权限，才能访问
        /// </summary>
        NeedRight
    }
}
