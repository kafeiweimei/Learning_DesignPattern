using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern.VisitorDemoOne
{
    /// <summary>
    /// 个人客户
    /// </summary>
    internal class PersonalCustomer : Customer
    {
        //联系电话
        public string TelPhone { get; set; } = string.Empty;
        //年龄
        public int Age { get; set; } = 0;

        public override void Accept(IVisitor visitor)
        {
           //回调访问者对象方法
           visitor.VisitPersonalCustomer(this);
        }
    }//Class_end
}
