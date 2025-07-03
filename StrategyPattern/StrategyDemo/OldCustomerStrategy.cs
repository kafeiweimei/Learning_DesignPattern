using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.StrategyDemo
{
    /// <summary>
    /// 具体的算法实现，为老客户计算应报价格
    /// </summary>
    internal class OldCustomerStrategy : IStrategy
    {
        public double CaculatePrice(double goodsPrice)
        {
            Console.WriteLine("\n对于老客户，统一折扣5%");
            return goodsPrice * (1 - 0.05);
        }
    }//Class_end
}
