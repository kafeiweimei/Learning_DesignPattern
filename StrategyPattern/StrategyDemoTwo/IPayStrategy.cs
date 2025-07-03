using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.StrategyDemoTwo
{
    /// <summary>
    /// 支付工资的策略接口，公司有多重支付工资的算法（如：现金、银行卡、现金加股票、现金加期权、美元支付等）
    /// </summary>
    internal interface IPayStrategy
    {
        /// <summary>
        /// 公司给某人真正支付工资策略
        /// </summary>
        /// <param name="payContext">支付工资的上下文（包含所需的数据）</param>
        void Pay(PayContext payContext);

    }//Interface_end
}
