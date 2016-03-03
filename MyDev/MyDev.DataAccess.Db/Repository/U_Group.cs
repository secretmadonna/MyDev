using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.DataAccess.Db.Repository
{
    [Table("U_Group")]
    public class U_Group
    {
        /// <summary>
        /// 组ID
        /// 主键
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 组名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 父组ID
        /// </summary>
        public int? FatherId { get; set; }
    }
}
