using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern.TemplateMethodInvoke
{
    /// <summary>
    /// 登录控制的模板方法需要的回调接口
    /// </summary>
    internal interface LoginCallback
    {
        /// <summary>
        /// 根据用户Id获取用户的信息
        /// </summary>
        /// <param name="loginId">用户Id</param>
        /// <returns></returns>
        LoginModel GetLoginUserInfo(string loginId);

        /// <summary>
        /// 对密码数据进行加密
        /// </summary>
        /// <param name="password">密码</param>
        /// <param name="template">LoginTemplate对象，通过它来调用LoginTemplate中定义的公共方法或默认实现</param>
        /// <returns></returns>
        string EncryptPassword(string password,LoginTemplate template);

        /// <summary>
        /// 判断用户填写的登录数据和存储中对应的数据是否匹配
        /// </summary>
        /// <param name="loginModel">用户填写的登录数据</param>
        /// <param name="lm">数据库中存储的用户数据</param>
        /// <param name="template">LoginTemplate对象通过调用在LoginTemplate中定义的公共方法或默认实现</param>
        /// <returns></returns>
        bool IsMatch(LoginModel loginModel,LoginModel lm,LoginTemplate template);

    }//Interface_end
}
