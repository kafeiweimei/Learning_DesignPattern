using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.StrategyDemo
{
    /// <summary>
    /// 具体的算法实现，为大客户计算应报的价格
    /// </summary>
    internal class LargeCustomerStrategy : IStrategy
    {
        public double CaculatePrice(double goodsPrice)
        {
            Console.WriteLine("\n对于大客户，统一折扣10%");
            return goodsPrice * (1 - 0.1);
        }
    }//Class_end
}
