using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.DataAccess.Db.Repository
{
    [Table("U_GroupRole")]
    public class U_GroupRole
    {
        /// <summary>
        /// 组ID
        /// </summary>
        [Key, Column(Order = 1)]
        public int GroupId { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        [Key, Column(Order = 2)]
        public int RoleId { get; set; }
    }
}
