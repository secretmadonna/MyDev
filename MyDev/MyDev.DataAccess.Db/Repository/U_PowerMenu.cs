using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.DataAccess.Db.Repository
{
    [Table("U_PowerMenu")]
    public class U_PowerMenu
    {
        /// <summary>
        /// 权限ID
        /// </summary>
        [Key, Column(Order = 1)]
        public int PowerId { get; set; }
        /// <summary>
        /// 菜单ID
        /// </summary>
        [Key, Column(Order = 2)]
        public int MenuId { get; set; }
    }
}
