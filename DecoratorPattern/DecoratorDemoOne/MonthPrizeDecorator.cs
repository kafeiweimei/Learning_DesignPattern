using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.DecoratorDemoOne
{
    /// <summary>
    /// 计算当月业务奖金（装饰器对象）
    /// </summary>
    internal class MonthPrizeDecorator : Decorator
    {
        public MonthPrizeDecorator(PrizeRule prizeRule) : base(prizeRule)
        {
        }

        public override double CaculatePrize(string user, DateTime start, DateTime end)
        {
            //1-获取前面运算出来的奖金
            double money = base.CaculatePrize(user,start,end);

            //2-计算当月业务奖金（按人员和时间去获取当月业务额度，然后乘以3%）
            double prize = TempDB.monthSaleMoneyDic[user] * 0.03;
            Console.WriteLine($"【{user}】当月业务奖金是【{prize}】");
            return money+prize;
        }

    }//Class_end
}
