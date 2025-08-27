using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern.VisitorDemoOne
{
    /// <summary>
    /// 企业客户
    /// </summary>
    internal class EnterpriseCustomer : Customer
    {
        //联系人
        public string LinkMan { get; set; } = string.Empty;
        //联系电话
        public string TelPhone { get; set; } = string.Empty;
        //企业注册地址
        public string RegisterAddress { get; set; } = string.Empty;

        public override void Accept(IVisitor visitor)
        {
            //回调访问者对象的方法
            visitor.VisitEnterpriseCustomer(this);
        }
    }//Class_end
}
