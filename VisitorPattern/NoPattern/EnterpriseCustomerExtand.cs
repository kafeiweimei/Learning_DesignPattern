using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern.NoPattern
{
    /// <summary>
    /// 企业客户
    /// </summary>
    internal class EnterpriseCustomerExtand : CustomerExtand
    {
        /// <summary>
        /// 联系人
        /// </summary>
        public string LinkMan { get; set; } = string.Empty;

        /// <summary>
        /// 联系电话
        /// </summary>
        public string TelPhone { get; set; } = string.Empty;

        /// <summary>
        /// 企业注册地址
        /// </summary>
        public string RegisterAddress { get; set; } = string.Empty;

        /// <summary>
        /// 企业客户提出的服务请求方法（这里只做示意）
        /// </summary>
        public override void ServiceRequest()
        {
            Console.WriteLine($"{this.CustomerName} 企业提出服务请求");
        }

        /// <summary>
        /// 企业客户对公司产品的偏好分析
        /// </summary>
        public override void PredilectionAnalyze()
        {
            //根据以往的购买历史，潜在的购买意向，以及客户所在行业的发展趋势预期等分析
            Console.WriteLine($"现状对企业客户【{this.CustomerName}】进行产品偏好分析");
        }

        /// <summary>
        /// 企业客户价值分析
        /// </summary>
        public override void WorthAnalyze()
        {
            //根据购买的金额大小，购买产品的产品和服务的多少，购买频率分析（企业客户的标准会比个人客户高）
            Console.WriteLine($"现在对企业客户【{this.CustomerName}】进行价值分析");
        }
    }//Class_end
}
