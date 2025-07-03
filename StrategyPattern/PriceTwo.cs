using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    //价格管理，主要完成计算向客户所报价格的功能
    internal class PriceTwo
    {
        //报价，对不同类型，计算不同的价格
        public double Quote(double goodsPrice,string customerType)
        {
            if ("普通客户".Equals(customerType))
            {
                return CaculatePriceForNormal(goodsPrice);
            }
            else if ("老客户".Equals(customerType))
            {
                return CaculatePriceForOld(goodsPrice);
            }
            else if ("大客户".Equals(customerType))
            {
                return CaculatePriceForLarge(goodsPrice);
            }
            //其余人都是报原价
            return goodsPrice;
        }

        //为新客户或普通顾客计算应报的价格
        private double CaculatePriceForNormal(double goodsPrice)
        {
            Console.WriteLine("对于新客户或普通客户，没有折扣");
            return goodsPrice;
        }

        //为老客户计算应报的价格
        private double CaculatePriceForOld(double goodsPrice)
        {
            Console.WriteLine("对于老客户，统一折扣5%");
            return goodsPrice * (1 - 0.05);
        }

        //为大客户计算应报的价格
        private double CaculatePriceForLarge(double goodsPrice)
        {
            Console.WriteLine("对于大客户，统一折扣10%");
            return goodsPrice * (1 - 0.1);
        }

    }//Class_end
}
