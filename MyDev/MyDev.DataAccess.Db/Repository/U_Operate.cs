using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.DataAccess.Db.Repository
{
    [Table("U_Operate")]
    public class U_Operate
    {
        /// <summary>
        /// 操作ID
        /// 主键
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 操作编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 操作名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 操作路径
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 父操作ID
        /// </summary>
        public int FatherId { get; set; }
    }
}
