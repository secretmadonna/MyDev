using MyDev.Api.WebApiLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyDev.Api.WebApi.Controllers
{
    /// <summary>
    /// 测试
    /// </summary>
    public class ValuesController : BaseApiController
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
        private List<TestUser> _userList = new List<TestUser>()
        {
            new TestUser { UserID = 1, UserName = "zhangsan", UserEmail = "zhangsan@sina.com" },
            new TestUser { UserID = 2, UserName = "lisi", UserEmail = "lisi@cnblogs.com" },
            new TestUser { UserID = 3, UserName = "wangwu", UserEmail = "wangwu@163.com" }
        };
        // GET api/values
        /// <summary>
        /// 获取所有用户列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<TestUser> Get()
        {
            return _userList;
        }

        // GET api/values/5
        /// <summary>
        /// 根据UserID获取用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        [HttpGet]
        public TestUser Get(int id)
        {
            return _userList.FirstOrDefault(m => m.UserID == id);
        }

        // POST api/values
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="model">新用户信息</param>
        /// <returns></returns>
        [HttpPost]
        public TestUser Post([FromBody]TestUser model)
        {
            _userList.Add(model);
            return model;
        }

        // PUT api/values/5
        /// <summary>
        /// 根据UserID编辑用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="model">用户新信息</param>
        /// <returns></returns>
        [HttpPut]
        public TestUser Put(int id, [FromBody]TestUser model)
        {
            var tu = _userList.FirstOrDefault(m => m.UserID == id);
            if (tu != null)
            {
                tu.UserName = model.UserName;
                tu.UserEmail = model.UserEmail;
            }
            return tu;
        }

        // DELETE api/values/5
        /// <summary>
        /// 根据UserID删除用户
        /// </summary>
        /// <param name="id">用户ID</param>
        [HttpDelete]
        public void Delete(int id)
        {
            _userList.Remove(_userList.FirstOrDefault(m => m.UserID == id));
        }
    }
}
