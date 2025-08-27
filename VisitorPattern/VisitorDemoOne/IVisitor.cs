using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern.VisitorDemoOne
{
    /// <summary>
    /// 访问者接口
    /// </summary>
    internal interface IVisitor
    {
        /// <summary>
        /// 访问企业客户，相当于给企业客户添加访问者的功能
        /// </summary>
        /// <param name="ec">企业客户对象</param>
        void VisitEnterpriseCustomer(EnterpriseCustomer ec);

        /// <summary>
        /// 访问个人客户，相当于给个人客户添加访问者功能
        /// </summary>
        /// <param name="pc">个人客户对象</param>
        void VisitPersonalCustomer(PersonalCustomer pc);

    }//Interface_end
}
