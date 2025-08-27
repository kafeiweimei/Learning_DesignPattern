using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern.NoPattern
{
    /// <summary>
    /// 个人客户
    /// </summary>
    internal class PersonalCustomerExtand : CustomerExtand
    {
        /// <summary>
        /// 联系电话
        /// </summary>
        public string TelPhone { get; set; } = string.Empty;

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; } = 0;

        /// <summary>
        /// 个人客户提出服务请求的方法（仅作示意）
        /// </summary>
        public override void ServiceRequest()
        {
            //个人客户提出的具体服务请求
            Console.WriteLine($"{this.CustomerName} 个人提出服务请求");
        }

        /// <summary>
        /// 个人客户对公司产品的偏好分析
        /// </summary>
        public override void PredilectionAnalyze()
        {
            Console.WriteLine($"现在对个人客户【{this.CustomerName}】进行产品偏好分析");
        }

        /// <summary>
        /// 个人客户价值分析
        /// </summary>
        public override void WorthAnalyze()
        {
            Console.WriteLine($"现在对【{this.CustomerName}】进行价值分析");
        }
    }//Class_end
}
