using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern.VisitorDemoOne
{
    /// <summary>
    /// 具体的访问者，实现对客户的偏好分析
    /// </summary>
    internal class PredilectionAnalyzeVisitor : IVisitor
    {
        public void VisitEnterpriseCustomer(EnterpriseCustomer ec)
        {
            //根据以往购买的历史，潜在购买意向以及客户所在行业的发展趋势，客户的预期等分析
            Console.WriteLine($"现在对企业客户【{ec.CustomerName}】进行产品偏好分析");
        }

        public void VisitPersonalCustomer(PersonalCustomer pc)
        {
            Console.WriteLine($"现在对个人客户【{pc.CustomerName}】进行偏好分析");
        }
    }//Class_end
}
