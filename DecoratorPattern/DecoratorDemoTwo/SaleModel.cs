using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.DecoratorDemoTwo
{
    /// <summary>
    /// 销售单数据模型
    /// </summary>
    internal class SaleModel
    {
        //销售商品
        public string? Goods { get; set; }
        //销售数量
        public int SaleNumber { get; set; }

        public override string ToString()
        {
            string str = $"商品名称是【{Goods}】购买的数量是【{SaleNumber}】";
            return str ;
        }

    }//Class_end
}
