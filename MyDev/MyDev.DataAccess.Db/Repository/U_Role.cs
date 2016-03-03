using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.DataAccess.Db.Repository
{
    [Table("U_Role")]
    public class U_Role
    {
        /// <summary>
        /// 角色ID
        /// 主键
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
