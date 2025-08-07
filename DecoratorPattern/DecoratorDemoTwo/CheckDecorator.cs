using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.DecoratorDemoTwo
{
    /// <summary>
    /// 实现权限控制的装饰器
    /// </summary>
    internal class CheckDecorator : Decorator1
    {
        public CheckDecorator(IGoodsSaleEbi ebi) : base(ebi)
        {
        }

        public override bool Sale(string user, string customer, SaleModel saleModel)
        {
            //这里演示就简单点，只让张三执行这个功能
            if ("张三".Equals(user))
            {
                return base.Sale(user, customer, saleModel);
            }
            else
            {
                Console.WriteLine($"对不起【{user}】你没有保存销售单的权限！");
                return false;
            }
        }

    }//Class_end
}
