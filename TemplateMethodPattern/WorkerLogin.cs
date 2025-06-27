using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern
{
    /// <summary>
    /// 工作人员登录的控制逻辑
    /// </summary>
    internal class WorkerLogin
    {
        /// <summary>
        /// 判断登录数据是否正确，正确则可以登录
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public bool Login(LoginModel loginModel)
        {
            WorkerModel workerModel = GetWorkerInfoByWorkerId(loginModel.UserId);
            if (workerModel!=null)
            {
                string encryptPwd = EncryptPassword(loginModel.Password);
                if (workerModel.WorkerId.Equals(loginModel.UserId)&&
                    workerModel.Password.Equals(encryptPwd))
                {
                    return true;
                }
            }

            return false;
        }

        //对密码加密
        private string EncryptPassword(string password)
        {
            if (password == null) return null;
            //这里执行对应的加密逻辑，此处以简单的MD5示意，不建议生产环境使用
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.Default.GetBytes(password);
            byte[] encryptdata = md5.ComputeHash(bytes);
            string str = Convert.ToBase64String(encryptdata);
            return str;
        }

        //根据工作人员编号获取工作人员详情
        private WorkerModel GetWorkerInfoByWorkerId(string userId)
        {
            WorkerModel workerModel = new WorkerModel();
            workerModel.Uuid = Guid.NewGuid().ToString("D");
            workerModel.WorkerId = userId;
            workerModel.UserName = "worker01";
            //注意正常我们从数据库获取的密码数据是加密的（这里只做演示）
            workerModel.Password = "JfnnlDI7RTiF9RgfG2JNCw==";

            return workerModel;
        }

    }//Class_end
}
