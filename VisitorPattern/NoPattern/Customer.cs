using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern.NoPattern
{
    /// <summary>
    /// 客户的父类
    /// </summary>
    abstract internal class Customer
    {
        /// <summary>
        /// 客户编号
        /// </summary>
        public string CustomerId { get; set; }=string.Empty;

        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// 客户提出的服务请求方法
        /// </summary>
        public abstract void ServiceRequest();

    }//Class_end
}
