using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.StrategyDemoTwo
{
    /// <summary>
    /// 美金现金支付
    /// </summary>
    internal class DollarCashPay : IPayStrategy
    {
        public void Pay(PayContext payContext)
        {
            Console.WriteLine($"\n现在给【{payContext.Name}】使用美元现金支付【{payContext.Money}】美金");
        }
    }//Class_end
}
