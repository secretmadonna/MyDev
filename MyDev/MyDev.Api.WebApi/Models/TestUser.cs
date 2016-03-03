using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.Api.WebApi.Models
{

    /// <summary>
    /// 测试用户Model
    /// </summary>
    public class TestUser
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [Required]
        public int UserID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        public string UserName { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [EmailAddress]
        public string UserEmail { get; set; }
    }
}
