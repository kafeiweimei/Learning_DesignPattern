using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern
{
    /// <summary>
    /// 普通用户登录控制的逻辑
    /// </summary>
    internal class NormalLogin
    {
        /// <summary>
        /// 判断登录数据是否正确，正确则可以登录
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public bool Login(LoginModel loginModel)
        {
            //模拟从数据库获取登录人员的信息【根据用户编号获取人员信息】
            UserModel userModel = GetUserInfoByUserId(loginModel.UserId);
            if (userModel != null)
            {
                if (userModel.UserId.Equals(loginModel.UserId) && 
                    userModel.Password.Equals(loginModel.Password))
                {
                    return true;
                }
            }

            return false;
        }

        //根据用户编号获取用户详情
        private UserModel GetUserInfoByUserId(string userId)
        {
            UserModel userModel = new UserModel();
            userModel.Uuid = Guid.NewGuid().ToString("D");
            userModel.UserId = userId;
            userModel.UserName = "Test";
            userModel.Password = "123456";

            return userModel;
        }

    }//Class_end
}
