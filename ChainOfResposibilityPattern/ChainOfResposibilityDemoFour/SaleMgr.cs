using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibilityPattern.ChainOfResposibilityDemoFour
{
    /// <summary>
    /// 真正处理销售业务功能的职责对象
    /// </summary>
    internal class SaleMgr : SaleHandler
    {
        public override bool Sale(string user, string customer, SaleModel saleModel)
        {
            //进行真正的业务逻辑处理
            Console.WriteLine($"【{user}】保存了【{customer}】购买的【{saleModel}】销售数据");
            return true;
        }
    }//Class_end
}
