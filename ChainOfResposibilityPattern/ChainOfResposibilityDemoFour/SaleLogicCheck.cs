using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibilityPattern.ChainOfResposibilityDemoFour
{
    /// <summary>
    /// 进行数据的逻辑检查的职责对象
    /// </summary>
    internal class SaleLogicCheck : SaleHandler
    {
        public override bool Sale(string user, string customer, SaleModel saleModel)
        {
            //进行数据的逻辑检查（如：检查ID的唯一性，主外键的对应关系等）
            //这里应该检查这种主外键的对应关系（如：销售商品是否存在）
            //我们这里为了演示就直接通过

            //通过上面的检测，那就向下继续执行
            return base.Successor.Sale(user, customer, saleModel);
        }
    }//Class_end
}
