using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.UserInterface.WebSite.Portal.WebLogic
{
    public class PageModel
    {
        /// <summary>
        /// 页面大小
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 页面索引
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 总计录数
        /// </summary>
        public int RecordCount { get; set; }

        /// <summary>
        /// 分页总数
        /// PageCount=(RecordCount/PageSize)+(RecordCount%PageSize>0?1:0)
        /// </summary>
        public int PageCount { get; set; }
    }
}
