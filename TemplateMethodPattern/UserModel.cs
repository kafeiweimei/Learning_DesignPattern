using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern
{
    /// <summary>
    /// 描述登录人员登录时填写的模型
    /// </summary>
    internal class UserModel
    {
        public string? Uuid { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set;}
        public string? Password { get; set; }

    }//Class_end
}
