
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern.TemplateMethodExtand
{
    /// <summary>
    /// 登录控制逻辑模板
    /// </summary>
    internal abstract class LoginTemplate
    {
        public bool Login(LoginModel loginModel)
        {
            LoginModel lm = GetLoginUserInfo(loginModel.LoginId);
            if (lm != null)
            {
                //对密码进行加密
                string encryptPwd = EncryptPassword(lm.Password);
                //比较是否匹配
                return IsMatch(loginModel, lm);
            }
            return false;
        }

        //根据登录编号获取数据库中对应编号用户的数据
        public abstract LoginModel GetLoginUserInfo(string loginId);

        /// <summary>
        /// 对密码数据进行加密【这里默认不加密】
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public virtual string EncryptPassword(string password)
        {
            return password;
        }

        /// <summary>
        /// 判断用户填写的数据与数据库中的数据是否匹配（修改为公有且可被覆写）
        /// </summary>
        /// <param name="loginModel">登录数据</param>
        /// <param name="lm">数据库存储的数据</param>
        /// <returns></returns>
        public virtual bool IsMatch(LoginModel loginModel, LoginModel lm)
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
