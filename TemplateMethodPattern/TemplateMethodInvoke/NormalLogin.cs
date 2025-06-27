using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern.TemplateMethodInvoke
{
    /// <summary>
    /// 普通人员登录
    /// </summary>
    internal class NormalLogin : LoginCallback
    {
        public string EncryptPassword(string password, LoginTemplate template)
        {
            return template.EncryptPassword(password);
        }

        public LoginModel GetLoginUserInfo(string loginId)
        {
            LoginModel model = new LoginModel();
            model.LoginId = loginId;
            model.Password = "123456";
            return model;
        }

        public bool IsMatch(LoginModel loginModel, LoginModel lm, LoginTemplate template)
        {
            //自己不覆盖直接调用模板默认实现
            return template.IsMatch(loginModel,lm);
        }
    }//Class_end
}
