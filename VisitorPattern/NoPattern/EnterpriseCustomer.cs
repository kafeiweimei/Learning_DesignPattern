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
    internal class EnterpriseCustomer : Customer
    {
        /// <summary>
        /// 联系人
        /// </summary>
        public string LinkMan {get; set;} = string.Empty;

        /// <summary>
        /// 联系电话
        /// </summary>
        public string TelPhone {get; set;} = string.Empty;

        /// <summary>
        /// 企业注册地址
        /// </summary>
        public string RegisterAddress {get; set;} = string.Empty;


        /// <summary>
        /// 企业客户提出的服务请求方法（这里只做示意）
        /// </summary>
        public override void ServiceRequest()
        {
            Console.WriteLine($"{this.CustomerName} 企业提出服务请求");
        }

    }//Class_end
}
