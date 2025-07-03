using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.StrategyDemo
{
    /// <summary>
    /// 新增的具体算法，为战略合作客户计算应报的价格
    /// </summary>
    internal class CooperateCustomerStragegy : IStrategy
    {
        public double CaculatePrice(double goodsPrice)
        {
            Console.WriteLine("\n对于战略客户，统一八折");
            return goodsPrice * 0.8;
        }
    }//Class_end
}
