using MyDev.BusinessLogic.BusinessObject;
using MyDev.BusinessLogic.Common;
using MyDev.DataAccess.Db.Context;
using MyDev.DataAccess.Db.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.BusinessLogic
{
    public class AccountBl
    {
        public static BusResult Login(LoginModel model)
        {
            var result = new BusResult() { Code = -9999, Summary = "操作失败", Detail = "系统异常，请稍后重试", Data = model };

            using (var db = new CommonDBContext())
            {
                var query = from t1 in db.RbacUser
                            where t1.Username == model.Username
                            select t1;
                var list = query.ToList();
                if (list == null || list.Count <= 0)
                {
                    //用户不存在
                    result.Code = -1;
                    result.Summary = "登录失败";
                    result.Detail = "用户名或密码错误";
                    result.Data = model;
                }
                else if (list.Count == 1)
                {
                    var entity = list[0];
                    if (entity.IsDelete)
                    {
                        //用户被删除
                        result.Code = -2;
                        result.Summary = "登录失败";
                        result.Detail = "用户名或密码错误";
                        result.Data = model;
                    }
                    if (entity.Password == model.Password)
                    {
                        if (entity.Status == (int)UserStatus.Normal)
                        {
                            result.Code = 1;
                            result.Summary = "登录成功";
                            result.Detail = "登录成功";
                            result.Data = model;
                        }
                        else
                        {
                            //用户状态不正常
                            result.Code = -2;
                            result.Summary = "登录失败";
                            result.Detail = "账户异常";
                            result.Data = model;
                        }
                    }
                    else
                    {
                        //密码错误
                        result.Code = -3;
                        result.Summary = "登录失败";
                        result.Detail = "用户名或密码错误";
                    }
                }
                else
                {
                    //用户名不唯一
                    result.Code = -1;
                    result.Summary = "登录失败";
                    result.Detail = "系统错误，请联系管理员";
                    result.Data = model;
                }
            }

            return result;
        }
    }
}
