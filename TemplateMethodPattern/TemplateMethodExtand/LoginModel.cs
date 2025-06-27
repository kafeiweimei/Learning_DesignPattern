using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern.TemplateMethodExtand
{
    /// <summary>
    /// 封装登录所需的数据对象【原有对象】
    /// </summary>
    internal class LoginModel
    {
        public string LoginId { get; set; }
        public string Password { get; set; }

    }//Class_end
}
