using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern.TemplateMethod
{
    /// <summary>
    /// 普通用户登录控制逻辑
    /// </summary>
    internal class NormalLogin : LoginTemplate
    {
        protected override LoginModel GetLoginUserInfo(string loginId)
        {
            LoginModel loginModel= new LoginModel();
            loginModel.LoginId = loginId;
            loginModel.Password = "123456";
            return loginModel;
        }

    }//Class_end
}
