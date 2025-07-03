using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.StrategyDemo
{
    /// <summary>
    /// 价格管理，主要完成计算向客户报价格功能
    /// </summary>
    internal class Price
    {
        //持有一个具体的策略对象
        private IStrategy strategy = null;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="strategy">具体的策略对象</param>
        public Price(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        /// <summary>
        /// 计算给客户的报价
        /// </summary>
        /// <param name="goodsPrice">商品价格（原价）</param>
        /// <returns></returns>
        public double Quote(double goodsPrice)
        {
            return this.strategy.CaculatePrice(goodsPrice);
        }


    }//Class_end
}
