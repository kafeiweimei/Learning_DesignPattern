using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.StrategyDemo
{
    /// <summary>
    /// 具体的算法实现，为新客户或普通用户计算应报价格
    /// </summary>
    internal class NormalCustomerStrategy : IStrategy
    {
        public double CaculatePrice(double goodsPrice)
        {
            Console.WriteLine("\n对于新客户或普通用户，没有折扣");
            return goodsPrice;
        }
    }//Class_end
}
