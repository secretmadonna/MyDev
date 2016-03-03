using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.DataAccess.Db.Repository
{
    [Table("U_UserRole")]
    public class U_UserRole
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Key, Column(Order = 1)]
        public string Username { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        [Key, Column(Order = 2)]
        public int RoleId { get; set; }
    }
}
