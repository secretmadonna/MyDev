using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.DataAccess.Db.Repository
{
    [Table("U_Menu")]
    public class U_Menu
    {
        /// <summary>
        /// 模块ID
        /// 主键
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 模块编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 模块路径
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 父模块ID
        /// </summary>
        public int FatherId { get; set; }
        /// <summary>
        /// 级别
        /// 1,2,3......
        /// </summary>
        public int Grade { get; set; }
        /// <summary>
        /// 是否显示
        /// true,false
        /// </summary>
        public bool IsShow { get; set; }
        /// <summary>
        /// 显示图标
        /// </summary>
        public string ShowIcon { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public string ShowName { get; set; }
        /// <summary>
        /// 显示顺序
        /// 1,2,3......
        /// </summary>
        public int ShowSequence { get; set; }
    }
}
