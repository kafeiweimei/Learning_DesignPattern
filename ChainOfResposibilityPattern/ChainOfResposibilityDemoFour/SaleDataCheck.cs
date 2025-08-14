using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibilityPattern.ChainOfResposibilityDemoFour
{
    /// <summary>
    /// 进行数据通用检查的职责对象
    /// </summary>
    internal class SaleDataCheck : SaleHandler
    {
        public override bool Sale(string user, string customer, SaleModel saleModel)
        {
            //数据通用检查
            if (string.IsNullOrEmpty(user))
            {
                Console.WriteLine("申请人不能为空");
                return false;
            }

            if (string.IsNullOrEmpty(customer))
            {
                Console.WriteLine("客户不能为空");
                return false;
            }

            if (saleModel==null)
            {
                Console.WriteLine("销售商品的数据不能为空");
                return false;
            }

            if (string.IsNullOrEmpty(saleModel.GoodsName))
            {
                Console.WriteLine("销售的商品不能为空");
                return false;
            }

            if (saleModel.SaleNumber<=0)
            {
                Console.WriteLine("销售商品的数量不能小于等于0");
                return false;
            }

            //如果通过了以上的检测，就继续向下继续执行
            return base.Successor.Sale(user, customer, saleModel);
        }
    }//Class_end
}
