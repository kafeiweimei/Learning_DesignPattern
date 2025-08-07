using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.DecoratorDemoTwo
{
    /// <summary>
    /// 具体的业务实现
    /// </summary>
    internal class GoodsSaleEbo : IGoodsSaleEbi
    {
        public bool Sale(string user, string customer, SaleModel saleModel)
        {
            Console.WriteLine($"【{user}】保存了【{customer}】购买【{saleModel}】的销售数据");
            return true;
        }
    }//Class_end
}
