using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.StrategyDemoTwo
{
    /// <summary>
    /// 支付工资的上下文（每个人支付工资的方式不同、工资不同）
    /// </summary>
    internal class PayContext
    {
        //应被支付工资的人员（我们这里为了示意就用名字了）
        private string name = string.Empty;

        //应被支付的工资金额
        private double money = 0.0;

        //支付工资的策略
        private IPayStrategy payStrategy=null;

        public string Name { get => name; }
        public double Money { get => money; }
        public IPayStrategy PayStrategy { get => payStrategy; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">应被支付工资的人员</param>
        /// <param name="money">应被支付的工资金额</param>
        /// <param name="payStrategy">支付工资的策略</param>
        public PayContext(string name,double money,IPayStrategy payStrategy)
        {
            this.name = name;
            this.money = money;
            this.payStrategy = payStrategy;
        }

        /// <summary>
        /// 立即支付工资
        /// </summary>
        public void PayNow()
        {
            this.payStrategy.Pay(this);
        }

    }//Class_end
}
