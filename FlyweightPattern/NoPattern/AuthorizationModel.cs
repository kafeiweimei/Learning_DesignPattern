using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightPattern.NoPattern
{
    /// <summary>
    /// 授权数据的模型
    /// </summary>
    internal class AuthorizationModel
    {
        /// <summary>
        /// 人员
        /// </summary>
        public string? User { get; set; }
        /// <summary>
        /// 安全实体
        /// </summary>
        public string? SecurityEntity { get; set; }
        /// <summary>
        /// 权限
        /// </summary>
        public string? Permit { get; set; }

        public override string ToString()
        {
            string str = $"【{User}】对【{SecurityEntity}】拥有【{Permit}】权限";
            return str;
        }

    }//Class_end
}
