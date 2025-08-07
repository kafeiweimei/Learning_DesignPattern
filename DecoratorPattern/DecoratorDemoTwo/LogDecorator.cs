using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.DecoratorDemoTwo
{
    /// <summary>
    /// 实现日志记录的装饰器
    /// </summary>
    internal class LogDecorator : Decorator1
    {
        public LogDecorator(IGoodsSaleEbi ebi) : base(ebi)
        {
        }

        public override bool Sale(string user, string customer, SaleModel saleModel)
        {
            //执行业务功能
            bool res = base.Sale(user, customer, saleModel);
            //执行业务功能后记录日志
            string curTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine($"日志记录【{user}】于【{curTime}】保存了一条销售记录，" +
                $"客户是【{customer}】购买记录是【{saleModel}】");
            return res;
        }

    }//Class_end
}
