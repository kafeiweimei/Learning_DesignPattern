using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.StrategyDemoTwo
{
    /// <summary>
    /// 银行卡支付
    /// </summary>
    internal class CardPay : IPayStrategy
    {
        public void Pay(PayContext payContext)
        {
            //这个新算法自己知道使用扩展,因此这里需要强制转换
            PayContextExtand payContextExtand = (PayContextExtand)payContext;

            Console.WriteLine($"\n现在给【{payContextExtand.Name}】的【{payContextExtand.Account}】账号支付【{payContextExtand.Money}】元人民币");

            //后续就是真正的连接银行接口进行对应的转账操作（这里仅作示意）

        }
    }//Class_end
}
