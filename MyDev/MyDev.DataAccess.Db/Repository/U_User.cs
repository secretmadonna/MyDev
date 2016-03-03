using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.DataAccess.Db.Repository
{
    [Table("U_User")]
    public class U_User
    {
        /// <summary>
        /// 用户名
        /// 主键
        /// </summary>
        [Key]
        public string Username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string Cid { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int? Sex { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string HandPhone { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 状态
        /// 1:正常,-1:禁用,-10:删除
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 最后1次登录系统的时间
        /// </summary>
        public DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        public string CreateUser { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 最后1次更新者
        /// </summary>
        public string LastUpdateUser { get; set; }
        /// <summary>
        /// 最后1次更新时间
        /// </summary>
        public DateTime LastUpdateTime { get; set; }
    }
}