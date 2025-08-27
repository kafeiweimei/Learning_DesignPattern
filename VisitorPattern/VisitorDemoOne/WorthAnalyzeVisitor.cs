using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern.VisitorDemoOne
{
    /// <summary>
    /// 具体的访问者，实现对客户价值的分析
    /// </summary>
    internal class WorthAnalyzeVisitor : IVisitor
    {
        public void VisitEnterpriseCustomer(EnterpriseCustomer ec)
        {
            //根据购买金额的大小，购买的产品和服务的多少、购买的频率进行分析，企业客户的标准必个人客户高
            Console.WriteLine($"现在对企业客户【{ec.CustomerName}】进行价值分析");
        }

        public void VisitPersonalCustomer(PersonalCustomer pc)
        {
            Console.WriteLine($"现在对个人客户【{pc.CustomerName}】进行价值分析");
        }
    }//Class_end
}
