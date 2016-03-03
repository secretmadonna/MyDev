using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.DataAccess.Db.Repository
{
    [Table("U_GroupUser")]
    public class U_GroupUser
    {
        /// <summary>
        /// 组ID
        /// </summary>
        [Key, Column(Order = 1)]
        public int GroupId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Key, Column(Order = 2)]
        public string Username { get; set; }
    }
}
