using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern.TemplateMethodInvoke
{
    /// <summary>
    /// 登录控制逻辑模板
    /// </summary>
    internal class LoginTemplate
    {
        public bool Login(LoginModel loginModel,LoginCallback loginCallback)
        {
            LoginModel lm = loginCallback.GetLoginUserInfo(loginModel.LoginId);
            if (lm != null)
            {
                //对密码进行加密
                string encryptPwd =loginCallback.EncryptPassword(loginModel.Password,this);
                //比较是否匹配
                loginModel.Password = encryptPwd;
                return loginCallback.IsMatch(loginModel, lm,this);
            }
            return false;
        }

        /// <summary>
        /// 对密码数据进行加密【这里默认不加密】
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public virtual string EncryptPassword(string password)
        {
            return password;
        }

        //判断用户填写的数据与数据库中的数据是否匹配
        public bool IsMatch(LoginModel loginModel, LoginModel lm)
        {
            if (loginModel != null && lm != null)
            {
                if (loginModel.LoginId.Equals(lm.LoginId) &&
                    loginModel.Password.Equals(lm.Password))
                {
                    return true;
                }
            }
            return false;
        }

    }//Class_end
}
