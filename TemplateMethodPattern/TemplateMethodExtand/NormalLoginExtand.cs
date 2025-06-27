using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern.TemplateMethodExtand
{
    /// <summary>
    /// 普通用户登录控制逻辑
    /// </summary>
    internal class NormalLoginExtand : LoginTemplate
    {
        public override LoginModel GetLoginUserInfo(string loginId)
        {
            NormalLoginModel normalLoginModel = new NormalLoginModel();
            normalLoginModel.LoginId = loginId;
            normalLoginModel.Password = "123456";
            normalLoginModel.Question = "你读过的一所学校名称是？";
            normalLoginModel.Answer = "xxx大学";
            return normalLoginModel;
        }

        /// <summary>
        /// 覆写模板的匹配方法（添加上验证问题与答案的校验逻辑）
        /// </summary>
        /// <param name="loginModel"></param>
        /// <param name="lm"></param>
        /// <returns></returns>
        public override bool IsMatch(LoginModel loginModel, LoginModel lm)
        {
            //原有的校验逻辑
            bool res=base.IsMatch(loginModel, lm);

            //新增的验证问题和答案校验逻辑
            if (res)
            {
                NormalLoginModel nloginModel = (NormalLoginModel)loginModel;
                NormalLoginModel nlm = (NormalLoginModel)lm;

                if (nloginModel.Question.Equals(nlm.Question)&& 
                    nloginModel.Answer.Equals(nlm.Answer))
                {
                    return true;
                }
            }
            return false;
        }

    }//Class_end
}
