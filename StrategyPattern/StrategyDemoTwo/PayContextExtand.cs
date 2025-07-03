using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.StrategyDemoTwo
{
    /// <summary>
    /// 新增的上下文内容
    /// </summary>
    internal class PayContextExtand : PayContext
    {
        //银行卡号
        private string account = string.Empty;

        public string Account { get => account; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">应被支付工资的人员</param>
        /// <param name="money">应被支付的工资金额</param>
        /// <param name="account">应被支付的银行卡号</param>
        /// <param name="payStrategy">支付工资的策略</param>
        public PayContextExtand(string name, double money,string account ,IPayStrategy payStrategy) : 
            base(name, money, payStrategy)
        {
            this.account = account;
        }


    }//Class_end
}
