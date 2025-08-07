using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.DecoratorDemoOne
{
    /// <summary>
    /// 计算累计奖金（装饰器对象）
    /// </summary>
    internal class SumPrizeDecorator : Decorator
    {
        public SumPrizeDecorator(PrizeRule prizeRule) : base(prizeRule)
        {
        }

        public override double CaculatePrize(string user, DateTime start, DateTime end)
        {
            //1-先获取前面运算出来的奖金
            double money = base.CaculatePrize(user, start, end);

            //2-计算累计奖金，实际情况应该按照人员去获取其对应的累计业务额度，然后再乘以0.1%
            //我们这里为了演示简单，就假定大家的累计业务额都是一百万1000000元
            double prize = 1000000 * 0.001;
            Console.WriteLine($"【{user}】的累计奖金是【{prize}】");
            return money+prize;
        }

    }//Class_end
}
