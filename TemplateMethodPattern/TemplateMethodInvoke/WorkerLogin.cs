using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern.TemplateMethodInvoke
{
    /// <summary>
    /// 工作人员登录
    /// </summary>
    internal class WorkerLogin : LoginCallback
    {
        public string EncryptPassword(string password, LoginTemplate template)
        {
            //这里实现接口的真正加密方法，不使用模板的加密方法

            if (string.IsNullOrEmpty(password)) return null;
            //这里执行对应的加密逻辑，此处以简单的MD5示意，不建议生产环境使用
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.Default.GetBytes(password);
            byte[] encryptdata = md5.ComputeHash(bytes);
            string str = Convert.ToBase64String(encryptdata);
            return str;
        }

        public LoginModel GetLoginUserInfo(string loginId)
        {
            LoginModel loginModel = new LoginModel();
            loginModel.LoginId = loginId;
            loginModel.Password = "JfnnlDI7RTiF9RgfG2JNCw==";
            return loginModel;
        }

        public bool IsMatch(LoginModel loginModel, LoginModel lm, LoginTemplate template)
        {
            //直接调用模板的的匹配方法
            return template.IsMatch(loginModel,lm);
        }
    }//Class_end
}
