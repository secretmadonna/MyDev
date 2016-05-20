using MyDev.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.BusinessLogic.CommonObject
{
    public class PageIn
    {
        /// <summary>
        /// 页索引
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 页尺寸
        /// </summary>
        public int PageSize { get; set; }
    }

    public class PageOut<T> where T : BaseEntity
    {
        /// <summary>
        /// 总数据量
        /// </summary>
        public int DataCount { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// 页索引
        /// 用户传入值，可能会被修正后，传回用户
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 页尺寸
        /// 用户传入值，可能会被修正后，传回用户
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public IList<T> Data { get; set; }
    }
}
