using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.DataAccess.Db.Repository
{
    [Table("Rbac_User")]
    public class Rbac_User
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
        public string RealName { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string IdNo { get; set; }
        /// <summary>
        /// 住址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 是否实名认证
        /// </summary>
        public bool IsRealNameAuth { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// 手机已验证
        /// </summary>
        public bool IsMobilePhoneAuth { get; set; }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 电子邮箱已验证
        /// </summary>
        public bool IsEmailAuth { get; set; }
        /// <summary>
        /// 状态
        /// 1:正常,-1:禁用
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        public string CreateUser { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 删除
        /// </summary>
        public bool IsDelete { get; set; }
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
