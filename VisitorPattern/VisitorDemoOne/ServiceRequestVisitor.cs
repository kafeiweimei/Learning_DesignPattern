using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern.VisitorDemoOne
{
    /// <summary>
    /// 具体的访问者，实现客户提出的服务请求功能
    /// </summary>
    internal class ServiceRequestVisitor : IVisitor
    {
        public void VisitEnterpriseCustomer(EnterpriseCustomer ec)
        {
            //企业客户提出的具体服务请求
            Console.WriteLine($"【{ec.CustomerName}】企业提出服务请求");
        }

        public void VisitPersonalCustomer(PersonalCustomer pc)
        {
           //个人客户提出的具体服务请求
           Console.WriteLine($"【{pc.CustomerName}】客户提出服务请求");
        }
    }//Class_end
}
