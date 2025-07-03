using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.StrategyDemoTwo
{
    /// <summary>
    /// 人民币现金支付
    /// </summary>
    internal class RMBCashPay : IPayStrategy
    {
        public void Pay(PayContext payContext)
        {
            Console.WriteLine($"\n现在给【{payContext.Name}】使用人民币现金支付【{payContext.Money}】元");
        }
    }//Class_end
}
