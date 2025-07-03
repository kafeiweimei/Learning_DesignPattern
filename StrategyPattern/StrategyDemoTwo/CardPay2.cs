using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.StrategyDemoTwo
{
    /// <summary>
    /// 支付到银行卡
    /// </summary>
    internal class CardPay2:IPayStrategy
    {
        //银行卡账号信息
        private string account=string.Empty;

        public string Account { get => account; }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="account">应被支付的银行卡号</param>
        public CardPay2(string account)
        {
            this.account = account;
        }
        public void Pay(PayContext payContext)
        {
            Console.WriteLine($"\n现在给【{payContext.Name}】的【{this.Account}】账号支付【{payContext.Money}】元人民币");

            //后续就是真正的连接银行接口进行对应的转账操作（这里仅作示意）
        }
    }//Class_end
}
