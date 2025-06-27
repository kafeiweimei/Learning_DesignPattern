using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern.TemplateMethod
{
    internal class WorkerLogin : LoginTemplate
    {
        protected override LoginModel GetLoginUserInfo(string loginId)
        {
            LoginModel loginModel=new LoginModel();
            loginModel.LoginId = loginId;
            loginModel.Password = "JfnnlDI7RTiF9RgfG2JNCw==";
            return loginModel;

        }

        protected override string EncryptPassword(string password)
        {
            if (password == null) return null;
            //这里执行对应的加密逻辑，此处以简单的MD5示意，不建议生产环境使用
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.Default.GetBytes(password);
            byte[] encryptdata = md5.ComputeHash(bytes);
            string str = Convert.ToBase64String(encryptdata);
            return str;
        }

    }//Class_end
}
