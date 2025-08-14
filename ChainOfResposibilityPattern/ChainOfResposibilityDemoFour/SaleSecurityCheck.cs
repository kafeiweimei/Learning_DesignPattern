using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibilityPattern.ChainOfResposibilityDemoFour
{
    /// <summary>
    /// 权限检查对象
    /// </summary>
    internal class SaleSecurityCheck : SaleHandler
    {
        public override bool Sale(string user, string customer, SaleModel saleModel)
        {
            //进行权限检查，为了演示方便就只让张三通过
            if ("张三".Equals(user))
            {
                return base.Successor.Sale(user, customer, saleModel);
            }
            else
            {
                Console.WriteLine($"抱歉，【{user}】你没有保存销售信息的权限");
                return false;
            }
        }
    }//Class_end
}
